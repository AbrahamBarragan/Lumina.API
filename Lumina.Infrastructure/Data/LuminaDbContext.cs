using Lumina.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lumina.Infrastructure.Data
{
    public class LuminaDbContext : DbContext
    {
        public LuminaDbContext(DbContextOptions<LuminaDbContext> options) : base(options)
        {
        }
        public DbSet<Reading> Readings { get; set; }
        public DbSet<Meter> Meters { get; set; }
    }
}
