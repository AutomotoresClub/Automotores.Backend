using System.Threading.Tasks;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Core
{
    public interface IUsuarioRepository
    {
         void Add(Usuario usuario);

         Task<Usuario> GetUsuario(int id);
    }
}