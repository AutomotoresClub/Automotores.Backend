using System.Collections.Generic;
using System.Threading.Tasks;
using Automotores.Backend.Core.Models;

namespace Automotores.Backend.Extensions
{
    public interface IVehiculoRepository
    {
        void Add(Vehiculo vehiculo);
        Task<Vehiculo> GetVehiculo(int id);
        Task<IEnumerable<Vehiculo>> GetVehiculos(int id);
        void Remove(Vehiculo vehiculo);

        bool ValidatePlaca(string placa);
    }
}