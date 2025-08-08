using FluentValidation;
using VaraticPrim.Framework.Models.ContactInfo;

namespace VaraticPrim.Framework.Validators;

public class CreateContactInfoModelValidator : AbstractValidator<CreateContactInfoModel>
{
    public CreateContactInfoModelValidator()
    {
        RuleFor(x => x.FirstName)
           .NotEmpty().WithMessage("First name cannot be empty.")
           .MaximumLength(100).WithMessage("First name must be less than 100 characters");

        RuleFor(x => x.LastName)
           .NotEmpty().WithMessage("Last name cannot be empty.")
           .MaximumLength(100).WithMessage("Last name must be less than 100 characters");

        RuleFor(x => x.Phone)
           .MaximumLength(100).WithMessage("Phone must be less than 50 characters");

        RuleFor(x => x.Mobile)
           .MaximumLength(100).WithMessage("Mobile must be less than 50 characters");
    }
}