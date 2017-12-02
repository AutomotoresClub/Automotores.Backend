using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Core.Models
{
    public class Promocion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(55)]
        public string Nombre { get; set; }

        [Required]
        public DateTime Vigencia { get; set; }

        [StringLength(255)]
        public string Imagen { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        public int Estado { get; set; }

        [StringLength(255)]
        public string Comentarios { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public Servicio Servicio { get; set; }

        public int ServicioId { get; set; }

        public Establecimiento Establecimiento { get; set; }

        public int EstablecimientoId { get; set; }

        public ICollection<PromocionMercado> Mercado { get; set; }

        public Promocion()
        {
            Mercado = new Collection<PromocionMercado>();
        }

    }
}