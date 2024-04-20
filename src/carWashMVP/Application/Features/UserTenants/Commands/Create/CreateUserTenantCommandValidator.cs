using FluentValidation;

namespace Application.Features.UserTenants.Commands.Create;

public class CreateUserTenantCommandValidator : AbstractValidator<CreateUserTenantCommand>
{
    public CreateUserTenantCommandValidator()
    {
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}