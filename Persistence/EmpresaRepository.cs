using System.Threading.Tasks;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Persistence
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AutomotoresDbContext context;
        public EmpresaRepository(AutomotoresDbContext context)
        {
            this.context = context;
        }

        public async Task<Empresa> GetEmpresa(int id)
        {
            return await context.Empresas
            .Include(e => e.MercadoObjetivo)
                .ThenInclude(em => em.Mercado)
            .Include(e => e.EmpresaServicios)
                .ThenInclude(es => es.Servicio)
            .Include(e => e.Ciudad)
            .Include(e => e.Regimen)
            .Include(e => e.TipoDocumento)
            .Include(e => e.User)
            .SingleOrDefaultAsync(e => e.Id == id);
        }

        public void Add(Empresa empresa)
        {
            context.Empresas.Add(empresa);
        }
    }
}