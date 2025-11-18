using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    /// <summary>
    /// Controller for test lifetime of services
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceLifetimeController : ControllerBase
    {
        /// <summary>
        /// New instance every time it requested
        /// </summary>
        private readonly TransientService _transient1, _transient2;

        /// <summary>
        /// One instance per HTTP request
        /// </summary>
        private readonly ScopedService _scoped1, _scoped2;

        /// <summary>
        /// Single instance for the lifetime of the application
        /// </summary>
        private readonly SingletonService _singleton;

        /// <summary>
        /// Constructor which assigns instance of diferent class to private instances
        /// </summary>
        /// <param name="transient1">First instance of TransientService</param>
        /// <param name="transient2">Second instance of TransientService</param>
        /// <param name="scoped1">First instance of ScopedService</param>
        /// <param name="scoped2">Second instance of ScopedService</param>
        /// <param name="singleton">Instance of SingletonService</param>
        public ServiceLifetimeController(TransientService transient1, TransientService transient2, ScopedService scoped1, ScopedService scoped2, SingletonService singleton)
        {
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton = singleton;
        }

        /// <summary>
        /// Get method to check different Id for different services
        /// </summary>
        /// <returns>Ids for all services</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Transient1 = _transient1.Id,
                Transient2 = _transient2.Id,
                Scoped1 = _scoped1.Id,
                Scoped2 = _scoped2.Id,
                Singleton = _singleton.Id
            });
        }
    }
}
