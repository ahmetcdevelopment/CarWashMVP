using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserTenants.Commands.Delete;

public class DeletedUserTenantResponse : IResponse
{
    public Guid Id { get; set; }
}