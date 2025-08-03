using FluentValidation;
using VaraticPrim.Framework.Models.User;

namespace VaraticPrim.Framework.Validators;

public class UserCreateModelValidator : AbstractValidator<CreateUserModel>
{
    public UserCreateModelValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required")
           .EmailAddress().WithMessage("Please enter a valid email address.");

        RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password is required");
    }
}