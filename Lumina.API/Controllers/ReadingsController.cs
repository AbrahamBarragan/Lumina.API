using Lumina.Application.Features.Readings;
using Lumina.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lumina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingsController : ControllerBase
    {
        private readonly IReadingRepository _readingRepository;
        private readonly ConsumptionService _consumptionService;
        public ReadingsController(IReadingRepository readingRepository, ConsumptionService consumptionService)
        {
            _readingRepository = readingRepository;
            _consumptionService = consumptionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReading(CreateReadingRequest request)
        {
            var reading = new Reading(request.MeterId, request.Value, request.ReadingDate);
            await _readingRepository.AddAsync(reading);
            return Ok();
        }

        [HttpGet("{meterId}")]
        public async Task<IActionResult> GetReadings(int meterId)
        {
            var readings = await _readingRepository.ListAsync(meterId);
            return Ok(readings);
        }

        [HttpGet("{meterId}/consumption")]
        public async Task<IActionResult> GetConsumption(int meterId)
        {
            try
            {
                var consumption = await _consumptionService.CalculateConsumptionAsync(meterId);
                return Ok(consumption);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
