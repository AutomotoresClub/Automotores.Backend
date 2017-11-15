using System.Collections.Generic;
using System.Collections.ObjectModel;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Controllers.Resources
{
    public class MercadoResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public ICollection<KeyValuePairResource> ClaseVehiculos { get; set; }

        public MercadoResource()
        {
            ClaseVehiculos = new Collection<KeyValuePairResource>();
        }
    }
}