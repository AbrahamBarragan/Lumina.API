using Lumina.Application.Features.Readings;
using Lumina.Domain.Entities;
using Lumina.Domain.Services;
using Microsoft.Extensions.Options;
using Moq;

namespace Lumina.Application.Tests;

public class ConsumptionServiceTests
{
    [Fact]
    public async Task CalculateConsumptionAsync_WithValidReadings_ShouldReturnCorrectConsumption()
    {
        var readings = new List<Reading>
        {
            new Reading(1, 100m, new DateTime(2026, 6, 1)),
            new Reading(1, 150m, new DateTime(2026, 7, 1))
        };

        var mockReadingRepository = new Mock<IReadingRepository>();
        mockReadingRepository
            .Setup(repo => repo.ListAsync(1))
            .ReturnsAsync(readings);

        var calculator = new ConsumptionCalculator();

        var options = Options.Create(new ElectricityRateOptions { PricePerKwh = 3.5m });

        var service = new ConsumptionService(mockReadingRepository.Object, calculator, options);

        var result = await service.CalculateConsumptionAsync(1);

        Assert.Equal(50m, result);

    }

    [Fact]
    public async Task CalculateConsumptionAsync_WithLessThanTwoReadings_ShouldThrowException()
    {
        // Arrange
        var readings = new List<Reading>
    {
        new Reading(1, 100m, new DateTime(2026, 6, 1))
    };

        var mockReadingRepository = new Mock<IReadingRepository>();
        mockReadingRepository
            .Setup(repo => repo.ListAsync(1))
            .ReturnsAsync(readings);

        var calculator = new ConsumptionCalculator();
        var options = Options.Create(new ElectricityRateOptions { PricePerKwh = 3.5m });
        var service = new ConsumptionService(mockReadingRepository.Object, calculator, options);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CalculateConsumptionAsync(1));
    }
}
