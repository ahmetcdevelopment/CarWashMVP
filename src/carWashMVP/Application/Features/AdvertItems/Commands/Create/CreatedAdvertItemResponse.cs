using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.AdvertItems.Commands.Create;

public class CreatedAdvertItemResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid AdvertId { get; set; }
    public AdvertItemCategory CategoryId { get; set; }
    public string Name { get; set; }
    public decimal AdditionalPrice { get; set; }
}