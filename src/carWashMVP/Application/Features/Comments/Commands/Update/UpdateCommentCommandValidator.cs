using FluentValidation;

namespace Application.Features.Comments.Commands.Update;

public class UpdateCommentCommandValidator : AbstractValidator<UpdateCommentCommand>
{
    public UpdateCommentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.ParentId).NotEmpty();
        RuleFor(c => c.Rating).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.BrandSerialId).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
    }
}