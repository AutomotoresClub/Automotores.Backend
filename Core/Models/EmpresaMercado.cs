namespace Automotores.Backend.Core.Models
{
    public class EmpresaMercado
    {
        public int EmpresaId { get; set; }

        public int MercadoId { get; set; }

        public Empresa Empresa { get; set; }

        public Mercado Mercado { get; set; }

    }
}