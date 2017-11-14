using System.Threading.Tasks;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;

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
            return await context.Empresas.FindAsync(id);
        }

        public void Add(Empresa empresa)
        {
            context.Empresas.Add(empresa);
        }
    }
}