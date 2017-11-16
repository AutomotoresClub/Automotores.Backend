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

        public DbSet<Mercado> Mercado { get; set; }

        public DbSet<ClaseVehiculo> ClaseVehiculo { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Linea> Lineas { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public AutomotoresDbContext(DbContextOptions<AutomotoresDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EmpresaMercado>().HasKey(vf =>
            new { vf.EmpresaId, vf.MercadoId });

            modelBuilder.Entity<EmpresaServicio>().HasKey(vf =>
            new { vf.EmpresaId, vf.ServicioId });
        }
    }
}