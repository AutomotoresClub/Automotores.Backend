namespace Automotores.Backend.Controllers.Resources
{
    public class SaveAdministradorResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public int EmpresaId { get; set; }
    }
}