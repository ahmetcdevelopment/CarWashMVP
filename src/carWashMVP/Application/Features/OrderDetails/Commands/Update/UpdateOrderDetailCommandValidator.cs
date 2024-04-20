using FluentValidation;

namespace Application.Features.OrderDetails.Commands.Update;

public class UpdateOrderDetailCommandValidator : AbstractValidator<UpdateOrderDetailCommand>
{
    public UpdateOrderDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.AdvertItemId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AdditionalPrice).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}