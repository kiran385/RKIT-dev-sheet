using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Filters.Filters;

namespace Filters.Controllers
{
    /// <summary>
    /// Controller to use custom filters
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [CustomAuthorizationFilter] //Authorization filter at controller level
    public class FilterDemoController : ControllerBase
    {
        [CustomResourceFilter]
        [CustomActionFilter]
        [CustomResultFilter]
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("Get method executed");
            return Ok("Hello from get method");
        }

        [HttpGet("get_exception")]
        public IActionResult GetException()
        {
            int zero = 0;
            int ans = 10 / zero;
            return Ok(ans);
        }
    }
}
