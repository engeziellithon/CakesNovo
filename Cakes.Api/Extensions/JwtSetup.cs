using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Cakes.Api.Extensions
{
    public static class JwtSetup
    {
        public static void AddJwtSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = configuration.GetValue<string>("Jwt:Issuer");
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = configuration.GetValue<string>("Jwt:Issuer"),
                       ValidateAudience = true,
                       ValidAudience = configuration.GetValue<string>("Jwt:Audience"),
                       ValidateLifetime = true
                   };
               });
        }
    }
}
