using FluentValidation;

namespace Application.Features.BrandSerials.Commands.Delete;

public class DeleteBrandSerialCommandValidator : AbstractValidator<DeleteBrandSerialCommand>
{
    public DeleteBrandSerialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}