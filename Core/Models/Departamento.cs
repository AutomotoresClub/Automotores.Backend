using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public ICollection<Ciudad> Ciudades { get; set; }

        public Departamento()
        {
            Ciudades = new Collection<Ciudad>();
        }

    }
}