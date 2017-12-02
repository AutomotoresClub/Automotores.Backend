using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Controllers.Resources
{
    public class PromocionResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime Vigencia { get; set; }

        public string Imagen { get; set; }

        public string Descripcion { get; set; }

        public string Comentarios { get; set; }

        public KeyValuePairResource Servicio { get; set; }

        public ICollection<KeyValuePairResource> Mercado { get; set; }

        public PromocionResource()
        {
            Mercado = new Collection<KeyValuePairResource>();
        }
    }
}