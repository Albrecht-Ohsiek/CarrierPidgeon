using System.Text;
using CarrierPidgeon.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CarrierPidgeon.Services
{
    public class AuthenticationServices
    {
        private readonly AuthenticationConfiguration _configuration;

        public AuthenticationServices(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = _configuration.JwtIssuer,
                        ValidAudience = _configuration.JwtAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.JwtSecret)),
                        RequireSignedTokens = true,
                        ValidAlgorithms = new[] { SecurityAlgorithms.HmacSha256 }
                    };
                });
        }
    }
}