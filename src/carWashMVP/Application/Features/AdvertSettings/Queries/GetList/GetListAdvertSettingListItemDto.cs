using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AdvertSettings.Queries.GetList;

public class GetListAdvertSettingListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public int DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}