using NArchitecture.Core.Application.Dtos;
using Domain.Enums;
using Domain.Enums;

namespace Application.Features.Orders.Queries.GetList;

public class GetListOrderListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid UserCarId { get; set; }
    public Guid WasherCarId { get; set; }
    public AdvertItemCategory Category { get; set; }
    public OrderStatus Status { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public double Enlem { get; set; }
    public double Boylam { get; set; }
    public string BeforePictures { get; set; }
    public string AfterPictures { get; set; }
    public string Note { get; set; }
    public string QrCode { get; set; }
}