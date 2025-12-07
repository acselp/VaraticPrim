using FluentValidation;
using NeoPay.Framework.Models.Utility;

namespace NeoPay.Framework.Validators;

public class CreateUtilityModelValidator : AbstractValidator<CreateUtilityModel>
{
    public CreateUtilityModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Utility name is required.");
        RuleFor(x => x.UnitType).NotEmpty().WithMessage("Unit type is required.");
    }
}
