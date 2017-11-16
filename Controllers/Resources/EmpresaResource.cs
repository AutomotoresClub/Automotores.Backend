using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automotores.Backend.Controllers.Resources
{
    public class EmpresaResource
    {
        public int Id { get; set; }

        public string Nit { get; set; }

        public string RazonSocial { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Password { get; set; }

        public int CodigoVerificacion { get; set; }

        public int NumeroEstablecimientos { get; set; }

        public int Estado { get; set; }

        public string Rut { get; set; }

        public string CamaraComercio { get; set; }

        public string SitioWeb { get; set; }

        public string ComentariosAdmin { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacion { get; set; }

        public RepresentanteResource Representante { get; set; }

        public KeyValuePairResource Ciudad { get; set; }

        public KeyValuePairResource Regimen { get; set; }

        public KeyValuePairResource TipoDocumento { get; set; }

        public ICollection<KeyValuePairResource> MercadoObjetivo { get; set; }

        public ICollection<KeyValuePairResource> EmpresaServicios { get; set; }

        public EmpresaResource()
        {
            MercadoObjetivo = new Collection<KeyValuePairResource>();
            EmpresaServicios = new Collection<KeyValuePairResource>();
        }
    }
}