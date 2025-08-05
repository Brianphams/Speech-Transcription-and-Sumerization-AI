using Microsoft.AspNetCore.Http;

namespace SpetoTex.DTOs
{
    public class FileUploadDto
    {
        public IFormFile Video { get; set; }
    }
}

