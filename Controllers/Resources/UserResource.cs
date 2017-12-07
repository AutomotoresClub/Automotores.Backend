using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Controllers.Resources
{
    public class UserResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe ser almenos {2} y un maximo {1} de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }


        [DataType(DataType.Password)]
        [Compare("Contraseña", ErrorMessage = "La contraseñas no coinciden.")]
        public string confirmarContraseña { get; set; }

        public string Rol { get; set; }

        public string UserName { get; set; }
    }
}