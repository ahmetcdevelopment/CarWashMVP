using FluentValidation;

namespace Application.Features.BrandSerials.Commands.Update;

public class UpdateBrandSerialCommandValidator : AbstractValidator<UpdateBrandSerialCommand>
{
    public UpdateBrandSerialCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ParentId).NotEmpty();
        RuleFor(c => c.Depth).NotEmpty();
        RuleFor(c => c.CaseType).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}