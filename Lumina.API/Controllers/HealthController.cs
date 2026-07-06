using Microsoft.AspNetCore.Mvc;

namespace Lumina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new
            {
                application = "Lumina",
                version = "1.0",
                status = "Running",
                serverTime = DateTime.UtcNow
            });
        }
    }
}
