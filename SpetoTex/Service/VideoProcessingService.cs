using Microsoft.AspNetCore.SignalR;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SpetoTex.Hubs;

namespace SpetoTex.Service
{
    public class VideoProcessingService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHubContext<VideoProcessingHub> _hubContext;

        public VideoProcessingService(IHttpClientFactory httpClientFactory, IHubContext<VideoProcessingHub> hubContext)
        {
            _httpClientFactory = httpClientFactory;
            _hubContext = hubContext;
        }

        public async Task ProcessVideoAsync(string filePath, string videoId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                using var content = new MultipartFormDataContent();
                await using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                content.Add(new StreamContent(fileStream), "file", Path.GetFileName(filePath));

                var response = await client.PostAsync("http://localhost:8000/transcribe", content);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"FastAPI error: {result}");
                }

                // Send result to SignalR clients
                await _hubContext.Clients.Group(videoId).SendAsync("ReceiveProcessingResult", result);

                // Clean up the file
                fileStream.Close();
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                // Send error to SignalR clients
                await _hubContext.Clients.Group(videoId).SendAsync("ReceiveProcessingResult",
                    $"{{\"error\": \"Processing failed: {ex.Message}\"}}");
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                throw;
            }
        }
    }
}