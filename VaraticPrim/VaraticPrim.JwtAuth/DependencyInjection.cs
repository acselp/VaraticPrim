using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace VaraticPrim.JwtAuth;

public static class DependencyInjection
{
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfigSection = configuration.GetSection("Jwt");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

                     options.Events = ConfigureJwtEvents();
                 });
    }

    private static JwtBearerEvents ConfigureJwtEvents()
    {
        var bearerEvents = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();

                var error = new JsonObject
                {
                    ["message"] = "Unauthorized"
                };

                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(error));
            },
            OnForbidden = context =>
            {
                var error = new JsonObject
                {
                    ["message"] = "Forbidden"
                };

                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return context.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
        };

        return bearerEvents;
    }
}