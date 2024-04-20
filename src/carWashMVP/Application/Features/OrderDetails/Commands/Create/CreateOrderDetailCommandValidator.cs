using FluentValidation;

namespace Application.Features.OrderDetails.Commands.Create;

public class CreateOrderDetailCommandValidator : AbstractValidator<CreateOrderDetailCommand>
{
    public CreateOrderDetailCommandValidator()
    {
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.AdvertItemId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AdditionalPrice).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}