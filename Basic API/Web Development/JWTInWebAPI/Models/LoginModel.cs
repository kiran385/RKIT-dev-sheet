using System;

namespace JWTInWebAPI.Models
{
    // Model representing the login credentials required for user authentication.
    public class LoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}