using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.BrandSerials.Queries.GetList;

public class GetListBrandSerialListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public int? Depth { get; set; }
    public CaseType CaseType { get; set; }
    public string Name { get; set; }
}