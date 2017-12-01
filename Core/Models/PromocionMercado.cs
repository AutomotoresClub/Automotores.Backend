namespace Automotores.Backend.Core.Models
{
    public class PromocionMercado
    {
        public int PromocionId { get; set; }

        public int MercadoId { get; set; }

        public Promocion Promocion { get; set; }

        public Mercado Mercado { get; set; }
    }
}