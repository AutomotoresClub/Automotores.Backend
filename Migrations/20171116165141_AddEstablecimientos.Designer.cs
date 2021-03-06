﻿// <auto-generated />
using Automotores.Backend.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Automotores.Backend.Migrations
{
    [DbContext(typeof(AutomotoresDbContext))]
    [Migration("20171116165141_AddEstablecimientos")]
    partial class AddEstablecimientos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Automotores.Backend.Core.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("EmpresaId");

                    b.Property<int>("Estado");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasMaxLength(16);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartamentoId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(2555);

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.ClaseVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MercadoId");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("MercadoId");

                    b.ToTable("ClaseVehiculo");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Indicativo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.DiasSemana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("DiasSemana");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CamaraComercio")
                        .HasMaxLength(255);

                    b.Property<int>("CiudadId");

                    b.Property<int>("CodigoVerificacion");

                    b.Property<string>("ComentariosAdmin")
                        .HasMaxLength(255);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Estado");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("IdentificacionRepresentante")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Nit")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("NombreRepresentante")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("NumeroEstablecimientos");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RegimenId");

                    b.Property<string>("Rut")
                        .HasMaxLength(255);

                    b.Property<string>("SitioWeb")
                        .HasMaxLength(255);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<int>("TipoDocumentoId");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.HasIndex("RegimenId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EmpresaMercado", b =>
                {
                    b.Property<int>("EmpresaId");

                    b.Property<int>("MercadoId");

                    b.HasKey("EmpresaId", "MercadoId");

                    b.HasIndex("MercadoId");

                    b.ToTable("EmpresaMercado");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EmpresaServicio", b =>
                {
                    b.Property<int>("EmpresaId");

                    b.Property<int>("ServicioId");

                    b.HasKey("EmpresaId", "ServicioId");

                    b.HasIndex("ServicioId");

                    b.ToTable("EmpresaServicio");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Establecimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdministradorId");

                    b.Property<int>("CiudadId");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Estado");

                    b.Property<DateTime>("FechaActualizacion");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("Imagen")
                        .HasMaxLength(255);

                    b.Property<float>("Latitud");

                    b.Property<float>("Longitud");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NombreContacto")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Ruta")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("TelefonoContacto")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("TipoJornada");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.HasIndex("CiudadId");

                    b.ToTable("Establecimientos");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EstablecimientoMercado", b =>
                {
                    b.Property<int>("EstablecimientoId");

                    b.Property<int>("MercadoId");

                    b.HasKey("EstablecimientoId", "MercadoId");

                    b.HasIndex("MercadoId");

                    b.ToTable("EstablecimientoMercado");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EstablecimientoServicio", b =>
                {
                    b.Property<int>("EstablecimientoId");

                    b.Property<int>("ServicioId");

                    b.HasKey("EstablecimientoId", "ServicioId");

                    b.HasIndex("ServicioId");

                    b.ToTable("EstablecimientoServicio");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EstablecimientoServicioEmergencia", b =>
                {
                    b.Property<int>("EstablecimientoId");

                    b.Property<int>("ServicioEmergenciId");

                    b.Property<int?>("ServicioEmergenciaId");

                    b.HasKey("EstablecimientoId", "ServicioEmergenciId");

                    b.HasIndex("ServicioEmergenciaId");

                    b.ToTable("EstablecimientoServicioEmergencia");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.HorarioEstablecimiento", b =>
                {
                    b.Property<int>("EstablecimientoId");

                    b.Property<int>("DiasSemanaId");

                    b.HasKey("EstablecimientoId", "DiasSemanaId");

                    b.HasIndex("DiasSemanaId");

                    b.ToTable("HorarioEstablecimiento");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Linea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MarcaId");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Lineas");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClaseVehiculoId");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("ClaseVehiculoId");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Mercado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Mercado");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Regimen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Regimen");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Imagen")
                        .HasMaxLength(255);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.ServicioEmergencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("ServiciosEmergencia");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.TipoDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("TipoDocumento");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Administrador", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Empresa", "Empresa")
                        .WithMany("Administradores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Ciudad", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Departamento", "Departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.ClaseVehiculo", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Mercado", "Mercado")
                        .WithMany("ClaseVehiculos")
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Empresa", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.Regimen", "Regimen")
                        .WithMany()
                        .HasForeignKey("RegimenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.TipoDocumento", "TipoDocumento")
                        .WithMany()
                        .HasForeignKey("TipoDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EmpresaMercado", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Empresa", "Empresa")
                        .WithMany("MercadoObjetivo")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.Mercado", "Mercado")
                        .WithMany()
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EmpresaServicio", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Empresa", "Empresa")
                        .WithMany("EmpresaServicios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Establecimiento", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Administrador", "Administrador")
                        .WithMany("Establecimientos")
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EstablecimientoMercado", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Establecimiento", "Establecimiento")
                        .WithMany()
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.Mercado", "Mercado")
                        .WithMany()
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EstablecimientoServicio", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Establecimiento", "Establecimiento")
                        .WithMany()
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.EstablecimientoServicioEmergencia", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Establecimiento", "Establecimiento")
                        .WithMany()
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.ServicioEmergencia", "ServicioEmergencia")
                        .WithMany()
                        .HasForeignKey("ServicioEmergenciaId");
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.HorarioEstablecimiento", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.DiasSemana", "DiasSemana")
                        .WithMany()
                        .HasForeignKey("DiasSemanaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Automotores.Backend.Core.Models.Establecimiento", "Establecimiento")
                        .WithMany()
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Linea", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.Marca", "Marca")
                        .WithMany("Lineas")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Automotores.Backend.Core.Models.Marca", b =>
                {
                    b.HasOne("Automotores.Backend.Core.Models.ClaseVehiculo", "ClaseVehiculo")
                        .WithMany("Marcas")
                        .HasForeignKey("ClaseVehiculoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
