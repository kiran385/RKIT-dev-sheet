using Microsoft.IdentityModel.Tokens;
using NoticeBoardAPI.MAL.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NoticeBoardAPI.BAL.Service
{
    /// <summary>
    /// Contains JWT Authentication logic implementation method
    /// </summary>
    public class BLJWTServiceHandler
    {
        /// <summary>
        /// IConfiguration instance
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initialize IConfiguration instance
        /// </summary>
        /// <param name="configuration"></param>
        public BLJWTServiceHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Implements JWT authentication logic
        /// </summary>
        /// <param name="modal">DTOLogin modal</param>
        /// <returns>JWT token</returns>
        public string? Authenticate(DTOLogin modal)
        {
            if(string.IsNullOrWhiteSpace(modal.UserName) || string.IsNullOrWhiteSpace(modal.Password))
            {
                return null;
            }
            if((modal.UserName != "Admin" && modal.UserName != "User") || modal.Password != "string")
            {
                return null;
            }

            string? issuer = _configuration["JWT:ValidIssuer"];
            string? audience = _configuration["JWT:ValidAudience"];
            string? key = _configuration["JWT:Secret"];
            DateTime tokenExpiry = DateTime.Now.AddMinutes(30);
            string role = modal.UserName == "Admin" ? "Admin" : "User";

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, modal.UserName),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = tokenExpiry,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string accessToken = tokenHandler.WriteToken(securityToken);

            return accessToken;
        }
    }
}
