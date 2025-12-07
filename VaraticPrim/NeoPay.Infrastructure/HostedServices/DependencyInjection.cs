using Microsoft.Extensions.DependencyInjection;

namespace NeoPay.Infrastructure.HostedServices;

public static class DependencyInjection
{
    public static void AddHostedServices(this IServiceCollection services)
    {
        services.AddHostedService<MigrationHostedService>();
    }
}