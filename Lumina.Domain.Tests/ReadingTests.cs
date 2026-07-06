using Lumina.Domain.Entities;

namespace Lumina.Domain.Tests
{
    public class ReadingTests
    {
        [Fact]
        public void Constructor_WithValidData_ShouldCreateReading()
        {
            DateTime readingDate = DateTime.UtcNow;
            Reading reading = new Reading(
                1, 
                100.5m, 
                readingDate);
            Assert.Equal(1, reading.MeterId);
            Assert.Equal(100.5m, reading.Value);
            Assert.Equal(readingDate, reading.ReadingDate);
        }

        [Fact]
        public void Constructor_WithInvalidMeterId_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Reading(0, 100.5m, DateTime.UtcNow));
        }
    }
}
