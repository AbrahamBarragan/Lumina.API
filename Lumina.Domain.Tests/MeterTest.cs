using Lumina.Domain.Entities;

namespace Lumina.Domain.Tests
{
    public class MeterTest
    {
        [Fact]
        public void Constructor_WithValidData_ShouldCreateMeter()
        {
            Meter meter = new Meter("SN12345");

            Assert.Equal("SN12345", meter.SerialNumber);
        }

        [Fact]
        public void Constructor_WithInvalidSerialNumber_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Meter(""));
            Assert.Throws<ArgumentException>(() => new Meter(null));
            Assert.Throws<ArgumentException>(() => new Meter("   "));
        }
    }
}
