using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Framework.Managers;
using VaraticPrim.Framework.Mappers;

namespace VaraticPrim.Framework;

public static class DependencyInjection
{
    public static void AddFramework(this IServiceCollection services)
    {
        services.AddMappers();
        services.AddManagers();
    }
}