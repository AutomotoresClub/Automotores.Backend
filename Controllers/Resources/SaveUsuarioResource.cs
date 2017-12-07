using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Automotores.Backend.Controllers.Resources
{
    public class SaveUsuarioResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DeviceId { get; set; }

        public int Estado { get; set; }

        public Blob? DatosEmergencia { get; set; }

        public int CiudadId { get; set; }

        [Required]
        public UserResource User { get; set; }
    }
}