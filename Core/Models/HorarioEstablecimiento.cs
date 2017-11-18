using System;
using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class HorarioEstablecimiento
    {
        public int EstablecimientoId { get; set; }

        public int DiasSemanaId { get; set; }

        [Required]
        public DateTime JornadaMañana { get; set; }

        public DateTime? SubJornadaMañana { get; set; }

        [Required]
        public DateTime JornadaTarde { get; set; }

        public DateTime? SubJornadaTarde { get; set; }

        public Establecimiento Establecimiento { get; set; }

        public DiasSemana DiasSemana { get; set; }
    }
}