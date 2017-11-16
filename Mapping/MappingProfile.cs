using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Automotores.Backend.Controllers.Resources;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Departamento, KeyValuePairResource>();
            CreateMap<Ciudad, KeyValuePairResource>();
            CreateMap<TipoDocumento, KeyValuePairResource>();
            CreateMap<Mercado, KeyValuePairResource>();
            CreateMap<Servicio, KeyValuePairResource>();

            CreateMap<Empresa, EmpresaResource>()
            .ForMember(er => er.Representante, opt => opt.MapFrom(e => new RepresentanteResource { Nombre = e.NombreRepresentante, Identificacion = e.IdentificacionRepresentante }))
            .ForMember(er => er.MercadoObjetivo, opt => opt.MapFrom(e => e.MercadoObjetivo.Select(em => em.MercadoId))).ForMember(er => er.EmpresaServicios, opt => opt.MapFrom(e => e.EmpresaServicios.Select(es => new KeyValuePairResource { Id = es.Servicio.Id, Nombre = es.Servicio.Nombre })))
            .ForMember(er => er.MercadoObjetivo, opt => opt.MapFrom(e => e.MercadoObjetivo.Select(em => new KeyValuePairResource { Id = em.Mercado.Id, Nombre = em.Mercado.Nombre })));

            CreateMap<Empresa, SaveEmpresaResource>()
            .ForMember(er => er.Representante, opt => opt.MapFrom(e => new RepresentanteResource { Nombre = e.NombreRepresentante, Identificacion = e.IdentificacionRepresentante }))
            .ForMember(er => er.MercadoObjetivo, opt => opt.MapFrom(e => e.MercadoObjetivo.Select(em => em.MercadoId)))
            .ForMember(er => er.EmpresaServicios, opt => opt.MapFrom(e => e.EmpresaServicios.Select(es => es.ServicioId)));

            CreateMap<Administrador, AdministradorResource>();
            CreateMap<Administrador, SaveAdministradorResource>();

            //Api Resource to Domain

            CreateMap<SaveEmpresaResource, Empresa>()
            .ForMember(e => e.Id, opt => opt.Ignore())
            .ForMember(e => e.NombreRepresentante, opt => opt.MapFrom(er => er.Representante.Nombre))
            .ForMember(e => e.IdentificacionRepresentante, opt => opt.MapFrom(er => er.Representante.Identificacion))
            .ForMember(e => e.MercadoObjetivo, opt => opt.Ignore())
            .AfterMap((er, e) =>
            {
                List<EmpresaMercado> mercadoRetirado = e.MercadoObjetivo.Where(f => !er.MercadoObjetivo.Contains(f.MercadoId)).ToList();

                foreach (var f in mercadoRetirado)
                {
                    e.MercadoObjetivo.Remove(f);
                }

                //Add new features
                var mercadoAgregado = er.MercadoObjetivo.Where(id => !e.MercadoObjetivo.Any(f => f.MercadoId == id)).Select(id => new EmpresaMercado { MercadoId = id });
                foreach (var f in mercadoAgregado)
                    e.MercadoObjetivo.Add(f);
            })
            .ForMember(e => e.EmpresaServicios, opt => opt.Ignore())
            .AfterMap((er, e) =>
            {
                List<EmpresaServicio> servicioRetirados = e.EmpresaServicios.Where(f => !er.EmpresaServicios.Contains(f.ServicioId)).ToList();

                foreach (var f in servicioRetirados)
                {
                    e.EmpresaServicios.Remove(f);
                }

                //Add new features
                var servicioAgregado = er.EmpresaServicios.Where(id => !e.EmpresaServicios.Any(f => f.ServicioId == id)).Select(id => new EmpresaServicio { ServicioId = id });
                foreach (var f in servicioAgregado)
                    e.EmpresaServicios.Add(f);
            });

            CreateMap<SaveAdministradorResource, Administrador>();
        }
    }
}