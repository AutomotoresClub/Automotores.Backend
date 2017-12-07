using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Automotores.Backend.Controllers.Resources
{
    public class SaveEmpresaResource
    {
        public int Id { get; set; }

        public string Nit { get; set; }

        public string RazonSocial { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public int CodigoVerificacion { get; set; }

        public int NumeroEstablecimientos { get; set; }

        public string Rut { get; set; }

        public string CamaraComercio { get; set; }

        public string SitioWeb { get; set; }

        public int CiudadId { get; set; }

        public int RegimenId { get; set; }

        public int TipoDocumentoId { get; set; }

        [Required]
        public RepresentanteResource Representante { get; set; }

        [Required]
        public UserResource User { get; set; }

        public ICollection<int> MercadoObjetivo { get; set; }

        public ICollection<int> EmpresaServicios { get; set; }

        public SaveEmpresaResource()
        {
            MercadoObjetivo = new Collection<int>();
            EmpresaServicios = new Collection<int>();
        }

    }
}