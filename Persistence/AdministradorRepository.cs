using System.Threading.Tasks;
using Automotores.Backend.Core;
using Automotores.Backend.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Persistence
{
    public class AdministradorRepository : IAdministradorRepository
    {
        private readonly AutomotoresDbContext context;
        public AdministradorRepository(AutomotoresDbContext context)
        {
            this.context = context;
        }

        public void Add(Administrador administrador)
        {
            context.Add(administrador);
        }

        public async Task<Administrador> GetAdministrador(int id)
        {
            return await context.Administradores.SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}