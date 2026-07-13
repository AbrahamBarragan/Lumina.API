using Lumina.Application.Features.Meters;
using Lumina.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lumina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetersController : ControllerBase
    {
        private readonly IMeterRepository _meterRepository;

        public MetersController(IMeterRepository meterRepository)
        {
            _meterRepository = meterRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeter(CreateMeterRequest request)
        {
            var meter = new Meter(request.SerialNumber);
            await _meterRepository.AddAsync(meter);
            return Ok();
        }
    }
}
