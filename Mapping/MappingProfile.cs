using System;
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
            CreateMap<HorarioEstablecimiento, HorarioResource>();
            CreateMap<ClaseVehiculo, ClaseVehiculoResource>();
            CreateMap<Marca, KeyValuePairResource>();
            CreateMap<Linea, KeyValuePairResource>();
            
            CreateMap<Empresa, EmpresaResource>()
            .ForMember(er => er.Representante, opt => opt.MapFrom(e => new RepresentanteResource { Nombre = e.NombreRepresentante, Identificacion = e.IdentificacionRepresentante }))
            .ForMember(er => er.MercadoObjetivo, opt => opt.MapFrom(e => e.MercadoObjetivo.Select(em => em.MercadoId)))
            .ForMember(er => er.EmpresaServicios, opt => opt.MapFrom(e => e.EmpresaServicios.Select(es => new KeyValuePairResource { Id = es.Servicio.Id, Nombre = es.Servicio.Nombre })))
            .ForMember(er => er.MercadoObjetivo, opt => opt.MapFrom(e => e.MercadoObjetivo.Select(em => new KeyValuePairResource { Id = em.Mercado.Id, Nombre = em.Mercado.Nombre })));

            CreateMap<Empresa, SaveEmpresaResource>()
            .ForMember(er => er.Representante, opt => opt.MapFrom(e => new RepresentanteResource { Nombre = e.NombreRepresentante, Identificacion = e.IdentificacionRepresentante }))
            .ForMember(er => er.MercadoObjetivo, opt => opt.MapFrom(e => e.MercadoObjetivo.Select(em => em.MercadoId)))
            .ForMember(er => er.EmpresaServicios, opt => opt.MapFrom(e => e.EmpresaServicios.Select(es => es.ServicioId)));

            CreateMap<Administrador, AdministradorResource>();
            CreateMap<Administrador, SaveAdministradorResource>();

            CreateMap<Establecimiento, EstablecimientoResource>()
            .ForMember(ec => ec.Contacto, opt => opt.MapFrom(e => new ContactoResource { Nombre = e.NombreContacto, Telefono = e.TelefonoContacto }))
            .ForMember(eg => eg.Geolocalizacion, opt => opt.MapFrom(e => new GeolocalizacionResource { Latitud = e.Latitud, Longitud = e.Longitud }))
            .ForMember(er => er.Servicios, opt => opt.MapFrom(e => e.Servicios.Select(es => new KeyValuePairResource { Id = es.Servicio.Id, Nombre = es.Servicio.Nombre })))
            .ForMember(er => er.Mercado, opt => opt.MapFrom(e => e.Mercado.Select(em => new KeyValuePairResource { Id = em.Mercado.Id, Nombre = em.Mercado.Nombre })))
            .ForMember(em => em.Horario, opt => opt.MapFrom(e => e.Horario.Select(em => new HorarioResource
            {
                JornadaMañana = em.JornadaMañana,
                SubJornadaMañana = em.SubJornadaMañana,
                JornadaTarde = em.JornadaTarde,
                SubJornadaTarde = em.SubJornadaTarde,
                Nombre = em.DiasSemana.Nombre,
                Id = em.DiasSemana.Id
            })));

            CreateMap<Establecimiento, SaveEstablecimientoResource>()
            .ForMember(ec => ec.Contacto, opt => opt.MapFrom(e => new ContactoResource { Nombre = e.NombreContacto, Telefono = e.TelefonoContacto }))
            .ForMember(eg => eg.Geolocalizacion, opt => opt.MapFrom(e => new GeolocalizacionResource { Latitud = e.Latitud, Longitud = e.Longitud }))
            .ForMember(em => em.Mercado, opt => opt.MapFrom(e => e.Mercado.Select(em => em.MercadoId)))
            .ForMember(em => em.Servicios, opt => opt.MapFrom(e => e.Servicios.Select(es => es.ServicioId)))
            .ForMember(em => em.Horario, opt => opt.MapFrom(e => e.Horario.Select(em => em.DiasSemanaId)));

            CreateMap<Promocion, PromocionResource>()
            .ForMember(er => er.Mercado, opt => opt.MapFrom(e => e.Mercado.Select(pm => new KeyValuePairResource { Id = pm.Mercado.Id, Nombre = pm.Mercado.Nombre })));

            CreateMap<Promocion, SavePromocionResource>()
            .ForMember(pm => pm.Mercado, opt => opt.MapFrom(e => e.Mercado.Select(em => em.MercadoId)));

            CreateMap<Usuario, UsuarioResource>()
            .ForMember(vr => vr.Departamento, opt => opt.MapFrom(v => v.Ciudad.Departamento));

            CreateMap<Usuario, SaveUsuarioResource>();

            CreateMap<Vehiculo, VehiculoResource>()
            .ForMember(vr => vr.Departamento, opt => opt.MapFrom(v => v.Ciudad.Departamento))
            .ForMember(vr => vr.Marca, opt => opt.MapFrom(v => v.Linea.Marca))
            .ForMember(vr => vr.ClaseVehiculo, opt => opt.MapFrom(v => v.Linea.Marca.ClaseVehiculo));

            CreateMap<Vehiculo, SaveVehiculoResource>();


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

            CreateMap<SaveAdministradorResource, Administrador>()
            .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<SaveEstablecimientoResource, Establecimiento>()
            .ForMember(e => e.Id, opt => opt.Ignore())
            .ForMember(e => e.NombreContacto, opt => opt.MapFrom(er => er.Contacto.Nombre))
            .ForMember(e => e.TelefonoContacto, opt => opt.MapFrom(er => er.Contacto.Telefono))
            .ForMember(e => e.Latitud, opt => opt.MapFrom(er => er.Geolocalizacion.Latitud))
            .ForMember(e => e.Longitud, opt => opt.MapFrom(er => er.Geolocalizacion.Longitud))
            .ForMember(e => e.Mercado, opt => opt.Ignore())
            .AfterMap((er, e) =>
            {
                List<EstablecimientoMercado> mercadoRetirado = e.Mercado.Where(f => !er.Mercado.Contains(f.MercadoId)).ToList();

                foreach (var f in mercadoRetirado)
                {
                    e.Mercado.Remove(f);
                }

                //Add new features
                var mercadoAgregado = er.Mercado.Where(id => !e.Mercado.Any(f => f.MercadoId == id)).Select(id => new EstablecimientoMercado { MercadoId = id });
                foreach (var f in mercadoAgregado)
                    e.Mercado.Add(f);
            })
            .ForMember(e => e.Servicios, opt => opt.Ignore())
            .AfterMap((er, e) =>
            {
                List<EstablecimientoServicio> servicioRetirados = e.Servicios.Where(f => !er.Servicios.Contains(f.ServicioId)).ToList();


                foreach (var f in servicioRetirados)
                {
                    e.Servicios.Remove(f);
                }
                //Add new features
                var servicioAgregado = er.Servicios.Where(id => !e.Servicios.Any(f => f.ServicioId == id)).Select(id => new EstablecimientoServicio { ServicioId = id });
                foreach (var f in servicioAgregado)
                    e.Servicios.Add(f);
            })
            .ForMember(e => e.Horario, opt => opt.Ignore())
            .AfterMap((er, e) =>
            {

                List<HorarioEstablecimiento> horarioRetirados = e.Horario.Where(h => !er.Horario.Any(f => f.Id == h.DiasSemanaId)).ToList();

                foreach (var h in horarioRetirados)
                {
                    e.Horario.Remove(h);
                }

                //Add new features
                var servicioAgregado = er.Horario.Where(horario => !e.Horario.Any(h => h.DiasSemanaId == horario.Id)).Select(horario => new HorarioEstablecimiento { DiasSemanaId = horario.Id, JornadaMañana = horario.JornadaMañana, JornadaTarde = horario.JornadaTarde, SubJornadaMañana = horario.SubJornadaMañana, SubJornadaTarde = horario.SubJornadaTarde });

                foreach (var f in servicioAgregado)
                {
                    e.Horario.Add(f);
                }

            });

            CreateMap<SavePromocionResource, Promocion>()
            .ForMember(e => e.Id, opt => opt.Ignore())
            .ForMember(e => e.Mercado, opt => opt.Ignore())
            .AfterMap((er, e) =>
            {
                List<PromocionMercado> mercadoRetirado = e.Mercado.Where(f => !er.Mercado.Contains(f.MercadoId)).ToList();
                foreach (var f in mercadoRetirado)
                {
                    e.Mercado.Remove(f);
                }

                //Add new features
                var mercadoAgregado = er.Mercado.Where(id => !e.Mercado.Any(f => f.MercadoId == id)).Select(id => new PromocionMercado { MercadoId = id });

                foreach (var f in mercadoAgregado)
                {
                    e.Mercado.Add(f);
                }
            });

            CreateMap<SaveUsuarioResource, Usuario>()
            .ForMember(e => e.Id, opt => opt.Ignore());

            CreateMap<SaveVehiculoResource, Vehiculo>()
            .ForMember(e => e.Id, opt => opt.Ignore());
        }
    }
}