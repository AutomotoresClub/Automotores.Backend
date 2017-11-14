using System.Threading.Tasks;
using Automotores.Backend.Core;

namespace Automotores.Backend.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutomotoresDbContext context;
        public UnitOfWork(AutomotoresDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}