namespace Lumina.Domain.Entities
{
    public class Meter
    {
        public Meter(string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                throw new ArgumentException("Serial number cannot be null or empty.", nameof(serialNumber));
            SerialNumber = serialNumber;
        }

        public int Id { get; private set; }
        public string SerialNumber { get; private set; }
        public ICollection<Reading> Readings { get; private set; } = new List<Reading>();
    }
}
