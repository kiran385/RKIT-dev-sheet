using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Middleware.Controllers
{
    /// <summary>
    /// Contains API endpoints
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Get method
        /// </summary>
        /// <returns>Appropriate message and status code</returns>
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("Hello from Get method");
        }
    }
}
