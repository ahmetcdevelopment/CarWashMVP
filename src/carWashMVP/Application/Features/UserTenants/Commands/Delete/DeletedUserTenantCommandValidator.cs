using FluentValidation;

namespace Application.Features.UserTenants.Commands.Delete;

public class DeleteUserTenantCommandValidator : AbstractValidator<DeleteUserTenantCommand>
{
    public DeleteUserTenantCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}