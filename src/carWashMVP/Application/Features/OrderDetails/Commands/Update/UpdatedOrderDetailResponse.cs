using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderDetails.Commands.Update;

public class UpdatedOrderDetailResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid AdvertItemId { get; set; }
    public string Name { get; set; }
    public decimal AdditionalPrice { get; set; }
    public string Description { get; set; }
}