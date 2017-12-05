using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Persistence
{
    public class PromocionRepository : IPromocionRepository
    {
        private readonly AutomotoresDbContext context;
        public PromocionRepository(AutomotoresDbContext context)
        {
            this.context = context;
        }

        public void Add(Promocion promocion)
        {
            context.Promociones.Add(promocion);
        }

        public async Task<Promocion> GetPromocion(int id)
        {
            return await context.Promociones
            .Include(e => e.Mercado)
                .ThenInclude(es => es.Mercado)
            .Include(e => e.Servicio)
            .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Promocion>> GetPromociones(int param, int optionalParam = 0, bool filter = false)
        {
            if (!filter)
            {
                return await context.Promociones
                .Include(e => e.Servicio)
                .Include(e => e.Mercado)
                    .ThenInclude(es => es.Mercado)
                .Where(e => e.EstablecimientoId == param).ToListAsync();
            }
            else
            {
                var claseVehiculo = param;
                var servicioVehiculo = optionalParam;

                return await context.Promociones
                .Include(e => e.Servicio)
                .Include(e => e.Mercado)
                  .ThenInclude(es => es.Mercado)
                .Where(e => e.Mercado.Any(f => f.Mercado.ClaseVehiculos.Any(c => c.Id == claseVehiculo)))
                .Where(e => e.ServicioId == servicioVehiculo)
                .ToListAsync();

            }
        }
    }
}