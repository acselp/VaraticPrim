using FluentValidation;
using NeoPay.Framework.Models.Connection;

namespace NeoPay.Framework.Validators;

public class UpdateConnectionModelValidator : AbstractValidator<UpdateConnectionModel>
{
    public UpdateConnectionModelValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Connection ID is required.");
        RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer ID is required.");
        RuleFor(x => x.UtilityId).GreaterThan(0).WithMessage("Utility ID is required.");
    }
}
