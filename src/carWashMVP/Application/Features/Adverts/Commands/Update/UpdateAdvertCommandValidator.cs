using FluentValidation;

namespace Application.Features.Adverts.Commands.Update;

public class UpdateAdvertCommandValidator : AbstractValidator<UpdateAdvertCommand>
{
    public UpdateAdvertCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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