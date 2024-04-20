using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderWashers.Queries.GetList;

public class GetListOrderWasherListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }
    public Guid WasherUserId { get; set; }
}