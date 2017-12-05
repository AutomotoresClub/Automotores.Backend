using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Automotores.Backend.Core.Models;
using Microsoft.AspNetCore.Http;

namespace Automotores.Backend.Controllers.Resources
{
    public class SaveEstablecimientoResource
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Descripcion { get; set; }

        public string Ruta { get; set; }

        public int TipoJornada { get; set; }

        public IFormFile Imagen { get; set; }

        public int Estado { get; set; }

        public int CiudadId { get; set; }

        public int AdministradorId { get; set; }

        [Required]
        public ContactoResource Contacto { get; set; }

        public GeolocalizacionResource Geolocalizacion { get; set; }

        public ICollection<int> Mercado { get; set; }

        public ICollection<int> Servicios { get; set; }

        public ICollection<HorarioEstablecimiento> Horario { get; set; }

        public ICollection<EstablecimientoServicioEmergencia> ServiciosEmergencia { get; set; }

        public SaveEstablecimientoResource()
        {
            Mercado = new Collection<int>();
            Servicios = new Collection<int>();
            Horario = new Collection<HorarioEstablecimiento>();
            ServiciosEmergencia = new Collection<EstablecimientoServicioEmergencia>();
        }
    }
}