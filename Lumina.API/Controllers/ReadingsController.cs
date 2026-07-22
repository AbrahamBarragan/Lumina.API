using Lumina.Application.Features.Readings;
using Microsoft.AspNetCore.Mvc;

namespace Lumina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadingsController : ControllerBase
    {
        private readonly IReadingRepository _readingRepository;
        private readonly ConsumptionService _consumptionService;
        private readonly ReadingService _readingService;
        public ReadingsController(IReadingRepository readingRepository, ConsumptionService consumptionService, ReadingService readingService)
        {
            _readingRepository = readingRepository;
            _consumptionService = consumptionService;
            _readingService = readingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReading(CreateReadingRequest request)
        {
            try
            {
                await _readingService.CreateReadingAsync(request.MeterId, request.Value, request.ReadingDate);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
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
        [HttpGet("{meterId}/estimated-cost")]
        public async Task<IActionResult> GetEstimatedCost(int meterId)
        {
            try
            {
                var cost = await _consumptionService.CalculateEstimatedCostAsync(meterId);
                return Ok(cost);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
