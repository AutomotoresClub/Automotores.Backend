using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class Ciudad
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2555)]
        public string Nombre { get; set; }

        public Departamento Departamento { get; set; }

        public int DepartamentoId { get; set; }
    }
}