using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPIDemo.BAL
{
    /// <summary>
    /// Contains methods for generate JWT token and validate JWT token 
    /// </summary>
    public class JWTHandler
    {
        private const string SecretKey = "GCRPEX5bdvS1LviHw9yBA2DWiQtvxuLx"; // The secret key used for token validation.

        /// <summary>
        /// Validates the JWT token and returns the ClaimsPrincipal if valid.
        /// </summary>
        /// <param name="token">JWT token</param>
        /// <returns>Claim principal given in the token</returns>
        public static ClaimsPrincipal ValidateJwtToken(string token)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            try
            {
                TokenValidationParameters parameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "Issuer",
                    ValidAudience = "Audience",
                    IssuerSigningKey = key
                };

                SecurityToken validatedToken;
                ClaimsPrincipal principal = handler.ValidateToken(token, parameters, out validatedToken);

                return principal;
            }
            catch
            {
                return null; // Invalid token
            }
        }

        /// <summary>
        /// Generates new JWT token
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="role">role for user</param>
        /// <returns>JWT token</returns>
        public static string GenerateJwtToken(string username,string role)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "Issuer",
                audience: "Audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}