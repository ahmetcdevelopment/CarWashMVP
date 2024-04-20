using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserTenants.Commands.Create;

public class CreatedUserTenantResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }
}