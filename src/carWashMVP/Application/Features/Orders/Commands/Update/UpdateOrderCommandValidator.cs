using FluentValidation;

namespace Application.Features.Orders.Commands.Update;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.UserCarId).NotEmpty();
        RuleFor(c => c.WasherCarId).NotEmpty();
        RuleFor(c => c.Category).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.Enlem).NotEmpty();
        RuleFor(c => c.Boylam).NotEmpty();
        RuleFor(c => c.BeforePictures).NotEmpty();
        RuleFor(c => c.AfterPictures).NotEmpty();
        RuleFor(c => c.Note).NotEmpty();
        RuleFor(c => c.QrCode).NotEmpty();
    }
}