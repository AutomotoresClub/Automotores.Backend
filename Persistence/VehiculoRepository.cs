using System.Threading.Tasks;
using Automotores.Backend.Core.Models;
using Automotores.Backend.Core;
using Microsoft.EntityFrameworkCore;
using Automotores.Backend.Extensions;
using System.Linq;
using System.Collections.Generic;

namespace Automotores.Backend.Persistence
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly AutomotoresDbContext context;
        public VehiculoRepository(AutomotoresDbContext context)
        {
            this.context = context;
        }

        public void Add(Vehiculo vehiculo)
        {
            context.Vehiculos.Add(vehiculo);
        }

        public async Task<Vehiculo> GetVehiculo(int id)
        {
            return await context.Vehiculos
            .Include(v => v.Ciudad)
                .ThenInclude(v => v.Departamento)
            .Include(v => v.Linea)
                .ThenInclude(v => v.Marca)
                .ThenInclude(v => v.ClaseVehiculo)
            .Include(v => v.ColorVehiculo)
            .Include(v => v.ServicioVehiculo).SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Vehiculo>> GetVehiculos(int id)
        {
            return await context.Vehiculos
            .Include(v => v.Ciudad)
                .ThenInclude(v => v.Departamento)
            .Include(v => v.Linea)
                .ThenInclude(v => v.Marca)
                .ThenInclude(v => v.ClaseVehiculo)
            .Include(v => v.ColorVehiculo)
            .Include(v => v.ServicioVehiculo).Where(e => e.UsuarioId == id).ToListAsync();
        }
    }
}