using Microsoft.Extensions.DependencyInjection;
using NeoPay.Framework.Validators;

namespace NeoPay.Framework;

public static class DependencyInjection
{
    public static void AddFramework(this IServiceCollection services)
    {
        services.AddValidators();
    }
}