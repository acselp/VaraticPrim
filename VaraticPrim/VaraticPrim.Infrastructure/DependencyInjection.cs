using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Application.Service;
using VaraticPrim.Framework;
using VaraticPrim.Infrastructure.HostedServices;
using VaraticPrim.Infrastructure.Options;
using VaraticPrim.Infrastructure.Persistence;
using VaraticPrim.Infrastructure.Repository;

namespace VaraticPrim.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddControllers(options =>
                 {
                     var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                     options.Filters.Add(new AuthorizeFilter(policy));
                 })
                .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });

        services.AddJwt(configuration);
        services.AddAuthorization();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontendCorsPolicy",
                              policy =>
                              {
                                  policy.WithOrigins(configuration["Frontend:BaseUrl"])
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                              });
        });
        services.AddOptions(configuration);
        services.AddOptions();
        services.AddFramework();
        services.AddRepositories();
        services.AddServices();
        services.AddPersistance(configuration);
        services.AddHostedServices();
    }

    private static void AddOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DbConnectionStringOptions>(configuration.GetSection(DbConnectionStringOptions.SectionName));
        services.Configure<FrontendOptions>(configuration.GetSection(FrontendOptions.SectionName));
    }
}