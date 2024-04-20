using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserTenants.Commands.Update;

public class UpdatedUserTenantResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }
}