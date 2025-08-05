using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SpetoTex.DTOs;
using SpetoTex.Service;

namespace Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoUploadController : ControllerBase
    {
        private readonly VideoProcessingService _videoProcessingService;
        private readonly IHttpClientFactory _httpClientFactory;

        public VideoUploadController(VideoProcessingService videoProcessingService, IHttpClientFactory httpClientFactory)
        {
            _videoProcessingService = videoProcessingService;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        [RequestSizeLimit(10L * 1024L * 1024L * 1024L)]
        public async Task<IActionResult> UploadVideo([FromForm] FileUploadDto fileUpload)
        {
            if (fileUpload == null || fileUpload.Video == null || fileUpload.Video.Length == 0)
                return BadRequest(new { message = "No file uploaded." });

            var allowedExtensions = new[] { ".mp3", ".mp4" };
            var fileExtension = Path.GetExtension(fileUpload.Video.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
                return BadRequest(new { message = "Only .mp3 or .mp4 files are allowed." });

            try
            {
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "TempVideos");
                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(fileUpload.Video.FileName)}";
                var savePath = Path.Combine(uploadFolder, fileName);

                // Save file and ensure it's closed
                using (var stream = new FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await fileUpload.Video.CopyToAsync(stream);
                }

                var videoId = Guid.NewGuid().ToString();

                // Enqueue Hangfire job to process the file and send to FastAPI
                BackgroundJob.Enqueue(() => _videoProcessingService.ProcessVideoAsync(savePath, videoId));

                return Ok(new { message = "Video is being processed.", videoId = videoId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}