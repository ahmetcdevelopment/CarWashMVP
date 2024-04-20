using FluentValidation;

namespace Application.Features.BrandSerials.Commands.Create;

public class CreateBrandSerialCommandValidator : AbstractValidator<CreateBrandSerialCommand>
{
    public CreateBrandSerialCommandValidator()
    {
        RuleFor(c => c.ParentId).NotEmpty();
        RuleFor(c => c.Depth).NotEmpty();
        RuleFor(c => c.CaseType).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}