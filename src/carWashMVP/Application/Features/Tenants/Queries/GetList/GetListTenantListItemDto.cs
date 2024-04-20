using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Tenants.Queries.GetList;

public class GetListTenantListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Biography { get; set; }
    public Guid Slug { get; set; }
    public string TaxNumber { get; set; }
    public string Address { get; set; }
}