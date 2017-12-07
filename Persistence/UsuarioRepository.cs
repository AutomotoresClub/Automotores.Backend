using Automotores.Backend.Core.Models;
using Automotores.Backend.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Persistence
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AutomotoresDbContext context;
        public UsuarioRepository(AutomotoresDbContext context)
        {
            this.context = context;

        }

        public void Add(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await context.Usuarios
            .Include(e => e.Ciudad)
                .ThenInclude(d => d.Departamento)
            .Include(e => e.User)
            .SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}