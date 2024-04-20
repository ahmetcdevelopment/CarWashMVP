using FluentValidation;

namespace Application.Features.OrderWashers.Commands.Delete;

public class DeleteOrderWasherCommandValidator : AbstractValidator<DeleteOrderWasherCommand>
{
    public DeleteOrderWasherCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}