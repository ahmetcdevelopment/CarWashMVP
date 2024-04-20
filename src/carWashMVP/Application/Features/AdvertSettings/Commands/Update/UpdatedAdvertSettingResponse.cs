using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdvertSettings.Commands.Update;

public class UpdatedAdvertSettingResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public int DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}