using Microsoft.Extensions.DependencyInjection;

namespace NeoPay.Framework.Managers;

public static class DependencyInjection
{
    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<CustomerManager>();
    }
}