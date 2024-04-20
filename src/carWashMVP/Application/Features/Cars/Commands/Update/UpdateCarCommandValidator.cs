using FluentValidation;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
{
    public UpdateCarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.BrandSerialId).NotEmpty();
        RuleFor(c => c.BrandYear).NotEmpty();
        RuleFor(c => c.PlateCode).NotEmpty();
        RuleFor(c => c.ColorCode).NotEmpty();
    }
}