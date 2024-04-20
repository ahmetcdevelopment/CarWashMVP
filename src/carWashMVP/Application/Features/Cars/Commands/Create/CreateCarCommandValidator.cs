using FluentValidation;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.BrandSerialId).NotEmpty();
        RuleFor(c => c.BrandYear).NotEmpty();
        RuleFor(c => c.PlateCode).NotEmpty();
        RuleFor(c => c.ColorCode).NotEmpty();
    }
}