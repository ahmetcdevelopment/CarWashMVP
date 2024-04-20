using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderWashers.Commands.Create;

public class CreatedOrderWasherResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }
    public Guid WasherUserId { get; set; }
}