using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Controllers.Resources
{
    public class ContactoResource
    {
        [Required]
        [StringLength(255)]
        public string NombreContacto { get; set; }

        [Required]
        [Range(7, 10, ErrorMessage = "La identificación del contacto debe ser entre 7 a 11")]
        public int TelefonoContacto { get; set; }
    }
}