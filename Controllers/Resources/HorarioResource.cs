using System;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Controllers.Resources
{
    public class HorarioResource
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public DateTime JornadaMañana { get; set; }

        public DateTime? SubJornadaMañana { get; set; }

        public DateTime JornadaTarde { get; set; }

        public DateTime? SubJornadaTarde { get; set; }

    }
}