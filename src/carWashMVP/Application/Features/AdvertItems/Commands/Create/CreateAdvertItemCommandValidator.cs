using FluentValidation;

namespace Application.Features.AdvertItems.Commands.Create;

public class CreateAdvertItemCommandValidator : AbstractValidator<CreateAdvertItemCommand>
{
    public CreateAdvertItemCommandValidator()
    {
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AdditionalPrice).NotEmpty();
    }
}