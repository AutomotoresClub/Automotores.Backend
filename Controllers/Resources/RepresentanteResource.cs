using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Controllers.Resources
{
    public class RepresentanteResource
    {
        [Required]
        [StringLength(255)]
        public string NombreRepresentante { get; set; }

        [Required]
        [Range(7, 10, ErrorMessage = "La identificación del representante debe ser entre 7 a 11")]
        public int IdentificacionRepresentante { get; set; }
    }
}