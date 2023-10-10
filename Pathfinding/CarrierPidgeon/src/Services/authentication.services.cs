using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace CarrierPidgeon.Services
{
    public class AuthenticationServices
    {
        private readonly IConfiguration _configuration;

        public AuthenticationServices(IConfiguration configuration)
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
                        ValidIssuer = _configuration["JwtAuth:JwtIssuer"],
                        ValidAudience = _configuration["JwtAuth:JwtAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuth:JwtSecret"]))
                    };
                });
        }
    }
}