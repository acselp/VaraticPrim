using Microsoft.Extensions.DependencyInjection;

namespace VaraticPrim.Framework.Managers;

public static class DependencyInjection
{
    public static void AddManagers(this IServiceCollection services)
    {
        services.AddScoped<UserManager>();
    }
}