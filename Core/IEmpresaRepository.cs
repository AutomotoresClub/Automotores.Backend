using System.Threading.Tasks;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Core
{
    public interface IEmpresaRepository
    {
         Task<Empresa> GetEmpresa(int id);

         void Add(Empresa empresa);
    }
}