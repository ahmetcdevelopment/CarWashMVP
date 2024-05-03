using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adverts.Commands.CreateWithAdvertItems;
public class CreatedWithAdvertItemsResponse:IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid WasherCarId { get; set; }
    public double Enlem { get; set; }
    public double Boylam { get; set; }
    public double Range { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public double PricePerDistance { get; set; }
    public double MinOrderAmount { get; set; }
}
