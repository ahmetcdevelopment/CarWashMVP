using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserTenants.Queries.GetList;

public class GetListUserTenantListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }
}