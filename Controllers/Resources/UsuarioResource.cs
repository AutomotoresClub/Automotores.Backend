using System.Reflection.Metadata;

namespace Automotores.Backend.Controllers.Resources
{
    public class UsuarioResource
    {
        public int Id { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DeviceId { get; set; }

        public Blob? DatosEmergencia { get; set; }

        public KeyValuePairResource Ciudad { get; set; }

        public KeyValuePairResource Departamento { get; set; }

    }
}