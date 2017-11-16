using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Automotores.Backend.Core.Models
{
    [Table("Empresas")]
    public class Empresa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Nit { get; set; }

        [Required]
        [StringLength(50)]
        public string RazonSocial { get; set; }

        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreRepresentante { get; set; }

        [Required]
        [StringLength(15)]
        public string IdentificacionRepresentante { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(16)]
        public string Password { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "El código de verificación debe ser 1")]
        public int CodigoVerificacion { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "El numero de establecimientos debe ser menor de dos digitos")]
        public int NumeroEstablecimientos { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "El estado debe ser menor de dos digitos")]
        public int Estado { get; set; }

        [StringLength(255)]
        public string Rut { get; set; }

        [StringLength(255)]
        public string CamaraComercio { get; set; }

        [StringLength(255)]
        public string SitioWeb { get; set; }

        [StringLength(255)]
        public string ComentariosAdmin { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public Ciudad Ciudad { get; set; }

        public int CiudadId { get; set; }

        public Regimen Regimen { get; set; }

        public int RegimenId { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public int TipoDocumentoId { get; set; }

        public ICollection<EmpresaMercado> MercadoObjetivo { get; set; }

        public ICollection<EmpresaServicio> EmpresaServicios { get; set; }

        public Empresa()
        {
            MercadoObjetivo = new Collection<EmpresaMercado>();
            EmpresaServicios = new Collection<EmpresaServicio>();
        }

    }
}