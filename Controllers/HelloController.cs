using Microsoft.AspNetCore.Mvc;

namespace Helloapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet("{name}")]
        public IActionResult GetPersonalMessage(string name)
        {
            return Ok(new { message = $"Hello, {name}! Welcome to ASP.NET Core." });
        }
    }
}
