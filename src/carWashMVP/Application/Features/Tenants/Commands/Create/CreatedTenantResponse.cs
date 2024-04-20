using NArchitecture.Core.Application.Responses;

namespace Application.Features.Tenants.Commands.Create;

public class CreatedTenantResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Biography { get; set; }
    public Guid Slug { get; set; }
    public string TaxNumber { get; set; }
    public string Address { get; set; }
}