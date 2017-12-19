using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Automotores.Backend.Controllers.Resources
{
    public class SaveVehiculoResource
    {
        public int Id { get; set; }

        [Required]
        public string Placa { get; set; }
        [Required]
        public string Modelo { get; set; }
        public IFormFile Imagen { get; set; }
        [Required]
        public DateTime? VigenciaTecnomecanica { get; set; }
        public DateTime? VigenciaTodoriesgo { get; set; }
        [Required]
        public DateTime? VigenciaSoat { get; set; }
        [Required]
        public int? CiudadId { get; set; }
        [Required]
        public int? LineaId { get; set; }
        [Required]
        public int? ServicioVehiculoId { get; set; }
        [Required]
        public int? ColorVehiculoId { get; set; }
        [Required]
        public int? UsuarioId { get; set; }

    }
}