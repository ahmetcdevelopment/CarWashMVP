using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderWashers.Commands.Update;

public class UpdatedOrderWasherResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }
    public Guid WasherUserId { get; set; }
}