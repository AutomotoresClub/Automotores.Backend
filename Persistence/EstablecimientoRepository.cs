using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Persistence
{
    public class EstablecimientoRepository : IEstablecimientoRepository
    {
        private readonly AutomotoresDbContext context;
        public EstablecimientoRepository(AutomotoresDbContext context)
        {
            this.context = context;

        }

        public void Add(Establecimiento establecimiento)
        {
            context.Add(establecimiento);
        }


        public async Task<Establecimiento> GetEstablecimiento(int id)
        {
            return await context.Establecimientos
            .Include(e => e.Servicios)
                .ThenInclude(em => em.Servicio)
            .Include(e => e.Mercado)
                .ThenInclude(es => es.Mercado)
            .Include(e => e.Horario)
             .ThenInclude(e => e.DiasSemana)
            .Include(e => e.Ciudad)
            .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Establecimiento>> GetEstablecimientos(int id)
        {
            return await context.Establecimientos
            .Include(e => e.Servicios)
                .ThenInclude(em => em.Servicio)
            .Include(e => e.Mercado)
                .ThenInclude(es => es.Mercado)
            .Include(e => e.Horario)
             .ThenInclude(e => e.DiasSemana)
            .Include(e => e.Ciudad)
            .Where(e => e.AdministradorId == id).ToListAsync();
        }
    }
}