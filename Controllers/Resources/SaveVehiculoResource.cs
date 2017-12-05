using System;
using Microsoft.AspNetCore.Http;

namespace Automotores.Backend.Controllers.Resources
{
    public class SaveVehiculoResource
    {
        public int Id { get; set; }

        public string Placa { get; set; }

        public string Modelo { get; set; }

        public IFormFile Imagen { get; set; }

        public DateTime VigenciaTecnomecanica { get; set; }

        public DateTime? VigenciaTodoriesgo { get; set; }

        public DateTime VigenciaSoat { get; set; }

        public int CiudadId { get; set; }

        public int LineaId { get; set; }

        public int ServicioVehiculoId { get; set; }

        public int ColorVehiculoId { get; set; }

        public int UsuarioId { get; set; }

    }
}