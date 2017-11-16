using System;
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

        public float Latitud { get; set; }

        public float Longitud { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public Ciudad Ciudad { get; set; }

        public int CiudadId { get; set; }

        public Administrador Administrador { get; set; }

        public int AdministradorId { get; set; }

    }
}