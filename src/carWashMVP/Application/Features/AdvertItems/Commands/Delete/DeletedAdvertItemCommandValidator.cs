using FluentValidation;

namespace Application.Features.AdvertItems.Commands.Delete;

public class DeleteAdvertItemCommandValidator : AbstractValidator<DeleteAdvertItemCommand>
{
    public DeleteAdvertItemCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}