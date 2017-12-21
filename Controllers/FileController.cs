using System.Threading.Tasks;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Automotores.Backend.Controllers
{
    [Route("/api/archivos")]
    public class FileController : Controller
    {
        private readonly IUploadService uploadService;
        private readonly FotosConfiguracion fotoConfiguracion;

        public FileController(IUploadService uploadService, IOptionsSnapshot<FotosConfiguracion> options)
        {
            this.uploadService = uploadService;
            this.fotoConfiguracion = options.Value;

        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null) return BadRequest("Null file");
            if (file.Length == 0) return BadRequest("Empty File");
            if (file.Length > this.fotoConfiguracion.MaxBytes) return BadRequest("Maximum file size exceeded");
            if (!fotoConfiguracion.IsSuported(file.FileName)) return BadRequest("File type is not valid");

            var url = await uploadService.UploadFile(file, "ac-automotor");

            if (url == null)
                return BadRequest("Something happened");

            return Ok(url);
        }
    }
}