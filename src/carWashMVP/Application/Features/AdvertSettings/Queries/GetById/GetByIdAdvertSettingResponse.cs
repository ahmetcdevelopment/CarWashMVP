using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdvertSettings.Queries.GetById;

public class GetByIdAdvertSettingResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public int DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}