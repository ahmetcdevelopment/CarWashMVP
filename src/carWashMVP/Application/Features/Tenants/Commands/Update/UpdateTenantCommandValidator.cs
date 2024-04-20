using FluentValidation;

namespace Application.Features.Tenants.Commands.Update;

public class UpdateTenantCommandValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdateTenantCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Photo).NotEmpty();
        RuleFor(c => c.Biography).NotEmpty();
        RuleFor(c => c.Slug).NotEmpty();
        RuleFor(c => c.TaxNumber).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
    }
}