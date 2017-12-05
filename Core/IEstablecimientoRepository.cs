using System.Collections.Generic;
using System.Threading.Tasks;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Core
{
    public interface IEstablecimientoRepository
    {
        void Add(Establecimiento establecimiento);

        Task<Establecimiento> GetEstablecimiento(int id);

        Task<IEnumerable<Establecimiento>> GetEstablecimientos(int param, int optionalParam = 0, bool filter = false);

        Task<IEnumerable<Establecimiento>> GetEstablecimientosEmergencia(int idServicioEmergencia);
    }
}