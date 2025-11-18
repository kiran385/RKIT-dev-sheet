using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoticeBoardAPI.BAL.Service;
using NoticeBoardAPI.MAL.DTO;

namespace NoticeBoardAPI.API
{
    /// <summary>
    /// Contains Login message
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLAuthController : ControllerBase
    {
        /// <summary>
        /// Instance of BLJWTServiceHandler
        /// </summary>
        private readonly BLJWTServiceHandler _jwtService;

        /// <summary>
        /// Initializes BLJWTServiceHandler instance
        /// </summary>
        /// <param name="jwtService"></param>
        public CLAuthController(BLJWTServiceHandler jwtService)
        {
            _jwtService = jwtService;
        }

        /// <summary>
        /// Check if user is authenticated or not
        /// </summary>
        /// <param name="modal">DTOLogin modal</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(DTOLogin modal)
        {
            string result = _jwtService.Authenticate(modal);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
