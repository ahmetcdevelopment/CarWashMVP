using FluentValidation;

namespace Application.Features.AdvertSettings.Commands.Delete;

public class DeleteAdvertSettingCommandValidator : AbstractValidator<DeleteAdvertSettingCommand>
{
    public DeleteAdvertSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}