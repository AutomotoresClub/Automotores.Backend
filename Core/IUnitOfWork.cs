using System.Threading.Tasks;

namespace Automotores.Backend.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}