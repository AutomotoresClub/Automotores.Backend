using System;
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

        [Required]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [StringLength(16)]
        public string Password { get; set; }

        public int Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public Empresa Empresa { get; set; }

        public int EmpresaId { get; set; }
    }
}