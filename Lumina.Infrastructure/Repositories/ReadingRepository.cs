using Lumina.Application.Features.Readings;
using Lumina.Domain.Entities;
using Lumina.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lumina.Infrastructure.Repositories
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly LuminaDbContext _context;

        public ReadingRepository(LuminaDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Reading reading)
        {
            _context.Readings.Add(reading);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reading>> ListAsync(int meterId)
        {
            return await _context.Readings.Where(r => r.MeterId == meterId).ToListAsync();
        }   
    }
}
