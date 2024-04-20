using FluentValidation;

namespace Application.Features.OrderWashers.Commands.Create;

public class CreateOrderWasherCommandValidator : AbstractValidator<CreateOrderWasherCommand>
{
    public CreateOrderWasherCommandValidator()
    {
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.WasherUserId).NotEmpty();
    }
}