using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Controllers.Resources
{
    public class LoginResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Contraseña { get; set; }
        [Required]
        public string Rol { get; set; }
    }
}