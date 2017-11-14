using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automotores.Backend.Core.Models
{
    public class ClaseVehiculo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Mercado Mercado { get; set; }

        public int MercadoId { get; set; }

        public ICollection<Marca> Marcas { get; set; }

        public ClaseVehiculo()
        {
            Marcas = new Collection<Marca>();
        }
    }
}