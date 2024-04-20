using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.BrandSerials.Commands.Create;

public class CreatedBrandSerialResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public int? Depth { get; set; }
    public CaseType CaseType { get; set; }
    public string Name { get; set; }
}