using FluentValidation;

namespace Application.Features.AdvertSettings.Commands.Create;

public class CreateAdvertSettingCommandValidator : AbstractValidator<CreateAdvertSettingCommand>
{
    public CreateAdvertSettingCommandValidator()
    {
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.DayOfWeek).NotEmpty();
        RuleFor(c => c.StartTime).NotEmpty();
        RuleFor(c => c.EndTime).NotEmpty();
    }
}