using Lumina.Domain.Entities;
using Lumina.Domain.Services;

namespace Lumina.Domain.Tests
{
    public class ConsumptionCalculatorTests
    {
        [Fact]
        public void Calculate_WithValidReadings_ShouldReturnCorrectConsumption()
        {
            var calculator = new ConsumptionCalculator();
            var previousReading = new Reading(1, 100m, new DateTime(2026, 6, 1));
            var currentReading = new Reading(1, 150m, new DateTime(2026, 7, 1));

            var result = calculator.Calculate(previousReading, currentReading);

            Assert.Equal(50m, result);
        }

        [Fact]
        public void Calculate_WithDifferentMeterIds_ShouldThrowException()
        {
            var calculator = new ConsumptionCalculator();
            var previousReading = new Reading(1, 100m, new DateTime(2026, 6, 1));
            var currentReading = new Reading(2, 150m, new DateTime(2026, 7, 1));

            Assert.Throws<ArgumentException>(() => calculator.Calculate(previousReading, currentReading));
        }

        [Fact]
        public void Calculate_WithCurrentDateBeforePreviousDate_ShouldThrowException()
        {
            var calculator = new ConsumptionCalculator();
            var previousReading = new Reading(1, 100m, new DateTime(2026, 7, 1));
            var currentReading = new Reading(1, 150m, new DateTime(2026, 6, 1));

            Assert.Throws<ArgumentException>(() => calculator.Calculate(previousReading, currentReading));
        }
    }
}