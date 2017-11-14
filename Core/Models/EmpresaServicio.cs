namespace Automotores.Backend.Core.Models
{
    public class EmpresaServicio
    {
        public int EmpresaId { get; set; }

        public int ServicioId { get; set; }

        public Empresa Empresa { get; set; }

        public Servicio Servicio { get; set; }
    }
}