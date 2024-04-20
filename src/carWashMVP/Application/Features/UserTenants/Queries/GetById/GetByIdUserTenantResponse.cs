using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserTenants.Queries.GetById;

public class GetByIdUserTenantResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }
}