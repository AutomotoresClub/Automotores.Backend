using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class Regimen
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
    }
}