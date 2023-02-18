using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Learn.Authenticate.Api.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private string _uploadDirecotroy = string.Empty;
        private IConfiguration _configuration;

        public FileController(
            IConfiguration configuration
        )
        {
            _configuration = configuration;
            _uploadDirecotroy = _configuration.GetSection("Upload:Folder").Value;
        }

        [HttpGet("{folder}/{id}")]
        public IActionResult GetFileAsync([Required] string folder, [Required] string id)
        {
            var path = $"{_uploadDirecotroy}\\{folder}\\{id}";
            if (System.IO.File.Exists(path))
            {
                return File(System.IO.File.OpenRead(path), "application/octet-stream", Path.GetFileName(path));
            }
            return NotFound();
        }
    }
}
