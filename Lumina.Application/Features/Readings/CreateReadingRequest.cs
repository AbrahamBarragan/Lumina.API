namespace Lumina.Application.Features.Readings
{
    public class CreateReadingRequest
    {
        public int MeterId { get; set; }
        public decimal Value { get; set; }
        public DateTime ReadingDate { get; set; }
    }
}
