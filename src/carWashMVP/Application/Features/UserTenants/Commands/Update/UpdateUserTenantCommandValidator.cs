using FluentValidation;

namespace Application.Features.UserTenants.Commands.Update;

public class UpdateUserTenantCommandValidator : AbstractValidator<UpdateUserTenantCommand>
{
    public UpdateUserTenantCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}