using FluentValidation;

namespace Application.Features.AdvertSettings.Commands.Update;

public class UpdateAdvertSettingCommandValidator : AbstractValidator<UpdateAdvertSettingCommand>
{
    public UpdateAdvertSettingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AdvertId).NotEmpty();
        RuleFor(c => c.DayOfWeek).NotEmpty();
        RuleFor(c => c.StartTime).NotEmpty();
        RuleFor(c => c.EndTime).NotEmpty();
    }
}