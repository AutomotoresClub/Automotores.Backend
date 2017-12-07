using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class Administrador
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

        public int Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public Empresa Empresa { get; set; }

        public int EmpresaId { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public ICollection<Establecimiento> Establecimientos { get; set; }

        public Administrador()
        {
            Establecimientos = new Collection<Establecimiento>();
        }
    }
}