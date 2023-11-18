using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CarrierPidgeon.Models;
using Microsoft.IdentityModel.Tokens;

namespace CarrierPidgeon.Keys
{
    public class Keygen
    {
        private readonly AuthenticationConfiguration _configuration;

        public Keygen(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.JwtSecret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>(){
                new Claim("_id", user._id.ToString()),
                new Claim(ClaimTypes.Name, user.name), 
                new Claim(ClaimTypes.Email, user.email)
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                _configuration.JwtIssuer,
                _configuration.JwtAudience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(_configuration.JwtLifetime),
                credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}