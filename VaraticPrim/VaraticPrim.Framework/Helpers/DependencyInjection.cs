using Microsoft.Extensions.DependencyInjection;
using VaraticPrim.Framework.Managers;

namespace VaraticPrim.Framework.Helpers;

public static class DependencyInjection
{
    public static void AddHelpers(this IServiceCollection services)
    {
        services.AddScoped<HashHelper>();
        services.AddScoped<TokenGeneratorHelper>();
    }
}