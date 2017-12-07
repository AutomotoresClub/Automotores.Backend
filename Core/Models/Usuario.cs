using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Automotores.Backend.Core.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(55)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string DeviceId { get; set; }

        [Required]
        public int Estado { get; set; }

        [NotMapped]
        public Blob? DatosEmergencia { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public Ciudad Ciudad { get; set; }

        public int CiudadId { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

    }
}