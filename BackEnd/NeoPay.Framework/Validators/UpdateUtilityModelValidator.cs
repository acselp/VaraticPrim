using FluentValidation;
using NeoPay.Framework.Models.Utility;

namespace NeoPay.Framework.Validators;

public class UpdateUtilityModelValidator : AbstractValidator<UpdateUtilityModel>
{
    public UpdateUtilityModelValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Utility ID is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Utility name is required.");
        RuleFor(x => x.UnitType).NotEmpty().WithMessage("Unit type is required.");
    }
}
