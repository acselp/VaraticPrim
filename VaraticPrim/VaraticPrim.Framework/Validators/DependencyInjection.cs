using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace VaraticPrim.Framework.Validators;

public static class DependencyInjection
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<UserCreateModelValidator>();
    }
}