namespace Automotores.Backend.Core.Models
{
    public class HorarioEstablecimiento
    {
        public int EstablecimientoId { get; set; }

        public int DiasSemanaId { get; set; }

        public Establecimiento Establecimiento { get; set; }

        public DiasSemana DiasSemana { get; set; }
    }
}