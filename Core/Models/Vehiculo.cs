using System;
using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Placa { get; set; }

        [Required]
        [StringLength(5)]
        public string Modelo { get; set; }

        [StringLength(255)]
        public string Imagen { get; set; }

        [Required]
        public DateTime VigenciaTecnomecanica { get; set; }

        public DateTime? VigenciaTodoriesgo { get; set; }

        [Required]
        public DateTime VigenciaSoat { get; set; }

        [Required]
        public int Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public int CiudadId { get; set; }

        public Ciudad Ciudad { get; set; }

        public int LineaId { get; set; }

        public Linea Linea { get; set; }

        public int ServicioVehiculoId { get; set; }

        public ServicioVehiculo ServicioVehiculo { get; set; }

        public int ColorVehiculoId { get; set; }

        public ColorVehiculo ColorVehiculo { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

    }
}