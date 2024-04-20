using FluentValidation;

namespace Application.Features.Adverts.Commands.Create;

public class CreateAdvertCommandValidator : AbstractValidator<CreateAdvertCommand>
{
    public CreateAdvertCommandValidator()
    {
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.WasherCarId).NotEmpty();
        RuleFor(c => c.Enlem).NotEmpty();
        RuleFor(c => c.Boylam).NotEmpty();
        RuleFor(c => c.Range).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.PricePerDistance).NotEmpty();
        RuleFor(c => c.MinOrderAmount).NotEmpty();
    }
}