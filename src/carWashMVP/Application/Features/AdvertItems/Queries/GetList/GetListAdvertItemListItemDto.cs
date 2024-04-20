using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.AdvertItems.Queries.GetList;

public class GetListAdvertItemListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid AdvertId { get; set; }
    public AdvertItemCategory CategoryId { get; set; }
    public string Name { get; set; }
    public decimal AdditionalPrice { get; set; }
}