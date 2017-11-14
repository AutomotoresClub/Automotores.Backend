using Microsoft.EntityFrameworkCore;

namespace Automotores.Backend.Persistence
{
    public class AutomotoresDbContext : DbContext
    {
        public AutomotoresDbContext(DbContextOptions<AutomotoresDbContext> options): base(options){ }
    }
}