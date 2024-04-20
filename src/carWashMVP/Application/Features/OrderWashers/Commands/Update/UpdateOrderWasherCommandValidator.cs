using FluentValidation;

namespace Application.Features.OrderWashers.Commands.Update;

public class UpdateOrderWasherCommandValidator : AbstractValidator<UpdateOrderWasherCommand>
{
    public UpdateOrderWasherCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.WasherUserId).NotEmpty();
    }
}