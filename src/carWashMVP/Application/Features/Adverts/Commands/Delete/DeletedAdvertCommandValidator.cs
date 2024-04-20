using FluentValidation;

namespace Application.Features.Adverts.Commands.Delete;

public class DeleteAdvertCommandValidator : AbstractValidator<DeleteAdvertCommand>
{
    public DeleteAdvertCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}