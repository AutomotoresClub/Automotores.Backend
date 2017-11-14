using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automotores.Backend.Core.Models
{
    public class Mercado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public ICollection<ClaseVehiculo> ClaseVehiculos { get; set; }

        public Mercado()
        {
            ClaseVehiculos = new Collection<ClaseVehiculo>();
        }
    }
}