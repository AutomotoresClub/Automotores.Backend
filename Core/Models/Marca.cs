using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automotores.Backend.Core.Models
{
    public class Marca
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public ClaseVehiculo ClaseVehiculo { get; set; }

        public int ClaseVehiculoId { get; set; }

        public ICollection<Linea> Lineas { get; set; }

        public Marca()
        {
            Lineas = new Collection<Linea>();
        }
    }
}