using System;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Controllers.Resources
{
    public class HorarioResource
    {
        public int CodigoDia { get; set; }

        public string NombreDia { get; set; }

        public string JornadaMañana { get; set; }

        public string SubJornadaMañana { get; set; }

        public string JornadaTarde { get; set; }

        public string SubJornadaTarde { get; set; }

        public string Disponibilidad { get; set; }

    }
}