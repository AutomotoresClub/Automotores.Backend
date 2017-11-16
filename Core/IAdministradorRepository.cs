using System.Threading.Tasks;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Core
{
    public interface IAdministradorRepository
    {
         void Add(Administrador administrador);

         Task<Administrador> GetAdministrador(int id);
    }
}