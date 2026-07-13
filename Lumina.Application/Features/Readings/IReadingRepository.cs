using Lumina.Domain.Entities;

namespace Lumina.Application.Features.Readings
{
    public interface IReadingRepository
    {
        Task AddAsync(Reading reading);

        Task<List<Reading>> ListAsync(int meterId);
    }
}
