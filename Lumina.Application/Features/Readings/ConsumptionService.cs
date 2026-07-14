using Lumina.Domain.Services;

namespace Lumina.Application.Features.Readings
{
    public class ConsumptionService
    {
        private readonly IReadingRepository _readingRepository;
        private readonly ConsumptionCalculator _calculator;
        public ConsumptionService(IReadingRepository readingRepository, ConsumptionCalculator calculator)
        {
            _readingRepository = readingRepository;
            _calculator = calculator;
        }
        public async Task<decimal> CalculateConsumptionAsync(int meterId)
        {
            var readings = await _readingRepository.ListAsync(meterId);
            var filteredReadings = readings
                .OrderBy(r => r.ReadingDate)
                .ToList();
            if (filteredReadings.Count < 2)
            {
                throw new InvalidOperationException("Not enough readings to calculate consumption.");
            }
            var firstReading = filteredReadings.First();
            var lastReading = filteredReadings.Last();
            return _calculator.Calculate(firstReading, lastReading);
        }
    }
}
