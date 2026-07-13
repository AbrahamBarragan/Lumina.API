using Lumina.Application.Features.Meters;
using Lumina.Infrastructure.Data;
using Lumina.Domain.Entities;

namespace Lumina.Infrastructure.Repositories
{
    public class MeterRepository : IMeterRepository
    {
        private readonly LuminaDbContext _context;

        public MeterRepository(LuminaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Meter meter)
        {
            await _context.Meters.AddAsync(meter);
            await _context.SaveChangesAsync();
        }

        public async Task<Meter?> GetMeterAsync(int id)
        {
            return await _context.Meters.FindAsync(id);
        }
    }
}
