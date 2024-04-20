using FluentValidation;

namespace Application.Features.Tenants.Commands.Create;

public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.Biography).NotEmpty();
        RuleFor(c => c.Slug).NotEmpty();
        RuleFor(c => c.TaxNumber).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
    }
}