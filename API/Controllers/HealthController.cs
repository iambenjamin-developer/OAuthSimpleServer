using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Root()
        {

            return Ok("OAuth 2.0 Server corriendo!");
        }
    }
}
