using Microsoft.Extensions.Options;
using Lumina.Domain.Services;

namespace Lumina.Application.Features.Readings
{
    public class ConsumptionService
    {
        private readonly IReadingRepository _readingRepository;
        private readonly ConsumptionCalculator _calculator;
        private readonly decimal _pricePerKwh;
        public ConsumptionService(IReadingRepository readingRepository, ConsumptionCalculator calculator, IOptions<ElectricityRateOptions> rateOptions)
        {
            _readingRepository = readingRepository;
            _calculator = calculator;
            _pricePerKwh = rateOptions.Value.PricePerKwh;
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
        public async Task<decimal> CalculateCostAsync(int meterId)
        {
            var consumption = await CalculateConsumptionAsync(meterId);
            return consumption * _pricePerKwh;
        }
    }
}
