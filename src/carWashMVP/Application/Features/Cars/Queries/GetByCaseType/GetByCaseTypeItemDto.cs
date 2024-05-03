using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetByCaseType;
public class GetByCaseTypeItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid BrandSerialId { get; set; }
    public int? BrandYear { get; set; }
    public string PlateCode { get; set; }
    public string ColorCode { get; set; }
}
