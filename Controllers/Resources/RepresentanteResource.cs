using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Controllers.Resources
{
    public class RepresentanteResource
    {
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(15)]
        public string Identificacion { get; set; }
    }
}