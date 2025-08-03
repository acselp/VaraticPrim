using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Framework.Helpers;
using VaraticPrim.Framework.Managers;
using VaraticPrim.Framework.Mappers;
using VaraticPrim.Framework.Validators;

namespace VaraticPrim.Framework;

public static class DependencyInjection
{
    public static void AddFramework(this IServiceCollection services)
    {
        services.AddMappers();
        services.AddManagers();
        services.AddHelpers();
        services.AddValidators();
    }
}