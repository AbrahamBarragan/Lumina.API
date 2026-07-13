using Lumina.Domain.Entities;

namespace Lumina.Application.Features.Meters
{
    public interface IMeterRepository
    {
        Task AddAsync(Meter meter);

        Task <Meter?> GetMeterAsync(int id);
    }
}
