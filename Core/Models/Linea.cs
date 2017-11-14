using System.ComponentModel.DataAnnotations.Schema;

namespace Automotores.Backend.Core.Models
{
    [Table("Lineas")]
    public class Linea
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Marca Marca { get; set; }

        public int MarcaId { get; set; }
        
    }
}