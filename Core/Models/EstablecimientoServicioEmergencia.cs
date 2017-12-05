using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class EstablecimientoServicioEmergencia
    {
        public int EstablecimientoId { get; set; }

        public int ServicioEmergenciId { get; set; }

        [StringLength(11)]
        public string Telefono { get; set; }

        public Establecimiento Establecimiento { get; set; }

        public ServicioEmergencia ServicioEmergencia { get; set; }
    }
}