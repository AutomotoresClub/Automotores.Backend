using System;
using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class Establecimiento
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(255)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreContacto { get; set; }

        [Required]
        [StringLength(10)]
        public string TelefonoContacto { get; set; }

        [Required]
        [StringLength(300)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(255)]
        public string Ruta { get; set; }

        [Required]
        public int TipoJornada { get; set; }

        [StringLength(255)]
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