using FluentValidation;

namespace Application.Features.AdvertItems.Commands.Update;

public class UpdateAdvertItemCommandValidator : AbstractValidator<UpdateAdvertItemCommand>
{
    public UpdateAdvertItemCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AdditionalPrice).NotEmpty();
    }
}