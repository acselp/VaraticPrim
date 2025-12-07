using FluentValidation;
using NeoPay.Framework.Models.Meter;

namespace NeoPay.Framework.Validators;

public class CreateMeterModelValidator : AbstractValidator<CreateMeterModel>
{
    public CreateMeterModelValidator()
    {
        RuleFor(x => x.SerialNumber).NotEmpty().WithMessage("Serial number is required.");
        RuleFor(x => x.ConnectionId).GreaterThan(0).WithMessage("Connection ID is required.");
    }
}
