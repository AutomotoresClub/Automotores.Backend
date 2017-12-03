using Automotores.Backend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Persistence
{

    public class AutomotoresDbContext : DbContext
    {

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Ciudad> Ciudades { get; set; }

        public DbSet<Regimen> Regimen { get; set; }

        public DbSet<TipoDocumento> TipoDocumento { get; set; }

        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<ServicioEmergencia> ServiciosEmergencia { get; set; }

        public DbSet<DiasSemana> DiasSemana { get; set; }

        public DbSet<Mercado> Mercado { get; set; }

        public DbSet<ClaseVehiculo> ClaseVehiculo { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Linea> Lineas { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Establecimiento> Establecimientos { get; set; }

        public DbSet<Promocion> Promociones { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<ServicioVehiculo> ServicioVehiculo { get; set; }

        public DbSet<ColorVehiculo> ColorVehiculo { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public AutomotoresDbContext(DbContextOptions<AutomotoresDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EmpresaMercado>().HasKey(vf =>
            new { vf.EmpresaId, vf.MercadoId });

            modelBuilder.Entity<EmpresaServicio>().HasKey(vf =>
            new { vf.EmpresaId, vf.ServicioId });

            modelBuilder.Entity<EstablecimientoMercado>().HasKey(vf =>
            new { vf.EstablecimientoId, vf.MercadoId });

            modelBuilder.Entity<EstablecimientoServicio>().HasKey(vf =>
            new { vf.EstablecimientoId, vf.ServicioId });

            modelBuilder.Entity<HorarioEstablecimiento>().HasKey(vf =>
            new { vf.EstablecimientoId, vf.DiasSemanaId });

            modelBuilder.Entity<EstablecimientoServicioEmergencia>().HasKey(vf =>
            new { vf.EstablecimientoId, vf.ServicioEmergenciId });

            modelBuilder.Entity<PromocionMercado>().HasKey(vf =>
            new { vf.PromocionId, vf.MercadoId });

        }
    }
}