using System.Web.Http;
using WebAPIDemo.BAL;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    /// <summary>
    /// Controller which contains method for login 
    /// </summary>
    public class AuthController : ApiController
    {
        /// <summary>
        /// Method for logged user in
        /// </summary>
        /// <param name="model">Modal contains username and password</param>
        /// <returns>JWT token if credentials are valid</returns>
        [HttpPost]
        [Route("api/auth/login")]
        public IHttpActionResult Login([FromBody] Login model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
                return BadRequest("Invalid credentials");

            var role = ValidateUser.ValidateUserCredentials(model.Username, model.Password);
            if (role == null)
                return Unauthorized();

            var token = JWTHandler.GenerateJwtToken(model.Username, role);
            return Ok(new { token });
        }
    }
}
