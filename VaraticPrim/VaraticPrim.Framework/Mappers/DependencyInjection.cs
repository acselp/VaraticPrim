using Microsoft.Extensions.DependencyInjection;

namespace VaraticPrim.Framework.Mappers;

public static class DependencyInjection
{
    public static void AddMappers(this IServiceCollection services)
    {
        services.AddScoped<UserMapper>();
    }
}