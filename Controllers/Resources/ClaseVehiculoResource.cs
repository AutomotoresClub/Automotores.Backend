using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Controllers.Resources
{
    public class ClaseVehiculoResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Mercado Mercado { get; set; }

    }
}