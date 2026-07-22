using Lumina.Application.Features.Meters;
using Lumina.Domain.Entities;

namespace Lumina.Application.Features.Readings
{
    public class ReadingService
    {
        private readonly IReadingRepository _readingRepository;
        private readonly IMeterRepository _meterRepository;

        public ReadingService(IReadingRepository readingRepository, IMeterRepository meterRepository)
        {
            _readingRepository = readingRepository;
            _meterRepository = meterRepository;
        }

        public async Task CreateReadingAsync(int meterId, decimal value, DateTime readingDate)
        {
            var meter = await _meterRepository.GetMeterAsync(meterId);
            if (meter == null)
                throw new InvalidOperationException($"Meter with id {meterId} does not exist.");
            var reading = new Reading(meterId, value, readingDate);
            await _readingRepository.AddAsync(reading);
        }
    }
}
