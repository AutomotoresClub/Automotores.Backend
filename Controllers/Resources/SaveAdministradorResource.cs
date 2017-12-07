using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Controllers.Resources
{
    public class SaveAdministradorResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public int EmpresaId { get; set; }

        [Required]
        public UserResource User { get; set; }


    }
}