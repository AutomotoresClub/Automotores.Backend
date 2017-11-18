using System.Threading.Tasks;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Core
{
    public interface IEstablecimientoRepository
    {
        void Add(Establecimiento establecimiento);
        Task<Establecimiento> GetEstablecimiento(int id);
    }
}