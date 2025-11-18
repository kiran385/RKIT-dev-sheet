using DependencyInjection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    /// <summary>
    /// Controller for message methods
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        /// <summary>
        /// Constructor Injection
        /// </summary>
        /// <param name="messageService"></param>
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Get method which gets message with constructor injection
        /// </summary>
        /// <returns>Message</returns>
        [HttpGet("get_with_constructor_injection")]
        public IActionResult GetMessage()
        {
            string message = _messageService.GetMessage();
            return Ok(message);
        }

        /// <summary>
        /// Get method which gets data with method injection
        /// </summary>
        /// <param name="messageService"></param>
        /// <returns>Message</returns>
        [HttpGet("get_with_method_injection")]
        public IActionResult GetMessageWithMethodInjection([FromServices] IMessageService messageService)
        {
            return Ok(messageService.GetMessage());
        }
    }
}
