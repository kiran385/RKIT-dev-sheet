using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    /// <summary>
    /// Controller for Log method
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        /// <summary>
        /// Declare instance of ILogger
        /// </summary>
        private readonly ILogger<LogController> _logger;

        /// <summary>
        /// Initializes instance of ILogger
        /// </summary>
        /// <param name="logger">Instance of ILogger</param>
        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method to test logging
        /// </summary>
        /// <returns>Exception message</returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("LogController Get method endpoint accesses");

            try
            {
                _logger.LogWarning("This is warning message");

                throw new Exception("Sample exception");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured: "+ ex.Message);

                return StatusCode(500, ex.Message);
            }
        }
    }
}
