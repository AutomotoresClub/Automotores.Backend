using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Controllers.Resources
{
    public class ContactoResource
    {
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }
    }
}