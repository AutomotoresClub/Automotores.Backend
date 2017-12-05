using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Controllers.Resources
{
    public class EstablecimientoResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string NombreContacto { get; set; }

        public string TelefonoContacto { get; set; }

        public string Descripcion { get; set; }

        public string Ruta { get; set; }

        public int TipoJornada { get; set; }

        public string Imagen { get; set; }

        public int Estado { get; set; }

        public string Disponibilidad { get; set; }

        public ContactoResource Contacto { get; set; }

        public GeolocalizacionResource Geolocalizacion { get; set; }

        public KeyValuePairResource Ciudad { get; set; }

        public ICollection<KeyValuePairResource> Servicios { get; set; }

        public ICollection<KeyValuePairResource> Mercado { get; set; }

        public ICollection<HorarioResource> Horario { get; set; }

        public EstablecimientoResource()
        {
            Servicios = new Collection<KeyValuePairResource>();
            Mercado = new Collection<KeyValuePairResource>();
            Horario = new Collection<HorarioResource>();
        }

    }
}