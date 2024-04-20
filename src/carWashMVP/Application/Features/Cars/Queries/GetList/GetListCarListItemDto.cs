using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid BrandSerialId { get; set; }
    public int? BrandYear { get; set; }
    public string PlateCode { get; set; }
    public string ColorCode { get; set; }
}