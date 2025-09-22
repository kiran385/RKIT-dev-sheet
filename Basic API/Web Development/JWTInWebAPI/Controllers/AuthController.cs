using System.Web.Http;
using JWTInWebAPI.Models;
using JWTInWebAPI.Handler;

// Controller for handling authentication-related actions like login and JWT token generation.
[RoutePrefix("api/auth")]
public class AuthController : ApiController
{
    [HttpPost]
    [Route("login")]
    public IHttpActionResult Login([FromBody] LoginModel login)
    {
        if (login.Username == "admin" && login.Password == "password")
        {
            var token = JWTHandler.GenerateJwtToken(login.Username);
            return Ok(new { token });
        }

        return Unauthorized();
    }

}