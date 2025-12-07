using FluentValidation;
using NeoPay.Framework.Models.Connection;

namespace NeoPay.Framework.Validators;

public class CreateConnectionModelValidator : AbstractValidator<CreateConnectionModel>
{
    public CreateConnectionModelValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer ID is required.");
        RuleFor(x => x.UtilityId).GreaterThan(0).WithMessage("Utility ID is required.");
    }
}
