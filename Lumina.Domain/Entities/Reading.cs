namespace Lumina.Domain.Entities
{
    public class Reading
    {
        public Reading(int meterId, decimal value, DateTime readingDate)
        {
            if (meterId <= 0)
                throw new ArgumentOutOfRangeException(nameof(meterId), "MeterId must be a positive integer.");

            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be a positive number.");

            if (readingDate > DateTime.UtcNow)
                throw new ArgumentOutOfRangeException(nameof(readingDate), "ReadingDate must be a valid date.");

            MeterId = meterId;
            Value = value;
            ReadingDate = readingDate;
        }

        public int Id { get; private set; }
        public int MeterId { get; private set; }
        public decimal Value { get; private set; }
        public DateTime ReadingDate { get; private set; }
        public Meter? Meter { get; private set; }
    }
}
