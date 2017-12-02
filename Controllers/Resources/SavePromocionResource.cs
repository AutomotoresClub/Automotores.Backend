using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automotores.Backend.Controllers.Resources
{
    public class SavePromocionResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime Vigencia { get; set; }

        public string Descripcion { get; set; }

        public int ServicioId { get; set; }

        public int EstablecimientoId { get; set; }

        public ICollection<int> Mercado { get; set; }

        public SavePromocionResource()
        {
            Mercado = new Collection<int>();
        }

    }
}