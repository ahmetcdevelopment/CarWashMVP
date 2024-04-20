using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderDetails.Queries.GetList;

public class GetListOrderDetailListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid AdvertItemId { get; set; }
    public string Name { get; set; }
    public decimal AdditionalPrice { get; set; }
    public string Description { get; set; }
}