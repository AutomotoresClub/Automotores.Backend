namespace Automotores.Backend.Core.Models
{
    public class EstablecimientoMercado
    {
        public int EstablecimientoId { get; set; }

        public int MercadoId { get; set; }

        public Establecimiento Establecimiento { get; set; }

        public Mercado Mercado { get; set; }
    }
}