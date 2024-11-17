using Microsoft.AspNetCore.Mvc;

namespace Lab_13.Server.Models
{
    public class RunLabRequest
    {
        [FromForm]
        public string ActionName { get; set; }

        [FromForm]
        public IFormFile InputFile { get; set; }
    }
}
