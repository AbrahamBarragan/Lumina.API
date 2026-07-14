using Lumina.Domain.Entities;

namespace Lumina.Domain.Services
{
    public class ConsumptionCalculator
    {
        public decimal Calculate(Reading previousReading, Reading currentReading)
        {
            if (previousReading.MeterId != currentReading.MeterId)
                throw new ArgumentException("Readings must belong to the same meter.");
            if (currentReading.ReadingDate <= previousReading.ReadingDate)
                throw new ArgumentException("Current reading date must be after the previous reading date.");
            return currentReading.Value - previousReading.Value;
        }
    }
}
