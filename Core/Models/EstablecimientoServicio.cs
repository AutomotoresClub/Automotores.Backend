namespace Automotores.Backend.Core.Models
{
    public class EstablecimientoServicio
    {
        public int EstablecimientoId { get; set; }

        public int ServicioId { get; set; }

        public Establecimiento Establecimiento { get; set; }

        public Servicio Servicio { get; set; }
    }
}