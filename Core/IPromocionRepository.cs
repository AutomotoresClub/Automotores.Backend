using System.Collections.Generic;
using System.Threading.Tasks;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Core
{
    public interface IPromocionRepository
    {
        void Add(Promocion promocion);

        Task<Promocion> GetPromocion(int id);

        Task<IEnumerable<Promocion>> GetPromociones(int id);
    }
}