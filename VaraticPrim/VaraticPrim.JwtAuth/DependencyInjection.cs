using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace VaraticPrim.JwtAuth;

public static class DependencyInjection
{
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfigSection = configuration.GetSection("Jwt");

        services.AddAuthentication(options =>
                 {
                     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                     options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
                     options.DefaultScheme             = JwtBearerDefaults.AuthenticationScheme;
                 })
                .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer      = true,
                         ValidateAudience    = true,
                         ValidateLifetime    = true,
                         ValidateTokenReplay = true,
                         ValidIssuer         = jwtConfigSection.GetSection("Issuer").Value,
                         ValidAudience       = jwtConfigSection.GetSection("Audience").Value,
                         ClockSkew           = TimeSpan.Zero,
                         IssuerSigningKey = new SymmetricSecurityKey(
                                                                     Encoding.UTF8.GetBytes(jwtConfigSection
                                                                        .GetSection("Key").Value))
                     };
                 });
    }
}