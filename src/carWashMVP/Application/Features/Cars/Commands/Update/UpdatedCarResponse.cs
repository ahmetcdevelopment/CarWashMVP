using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cars.Commands.Update;

public class UpdatedCarResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid BrandSerialId { get; set; }
    public int? BrandYear { get; set; }
    public string PlateCode { get; set; }
    public string ColorCode { get; set; }
}