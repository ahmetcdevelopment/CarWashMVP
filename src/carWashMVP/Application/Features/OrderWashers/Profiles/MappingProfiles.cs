using Application.Features.OrderWashers.Commands.Create;
using Application.Features.OrderWashers.Commands.Delete;
using Application.Features.OrderWashers.Commands.Update;
using Application.Features.OrderWashers.Queries.GetById;
using Application.Features.OrderWashers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.OrderWashers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OrderWasher, CreateOrderWasherCommand>().ReverseMap();
        CreateMap<OrderWasher, CreatedOrderWasherResponse>().ReverseMap();
        CreateMap<OrderWasher, UpdateOrderWasherCommand>().ReverseMap();
        CreateMap<OrderWasher, UpdatedOrderWasherResponse>().ReverseMap();
        CreateMap<OrderWasher, DeleteOrderWasherCommand>().ReverseMap();
        CreateMap<OrderWasher, DeletedOrderWasherResponse>().ReverseMap();
        CreateMap<OrderWasher, GetByIdOrderWasherResponse>().ReverseMap();
        CreateMap<OrderWasher, GetListOrderWasherListItemDto>().ReverseMap();
        CreateMap<IPaginate<OrderWasher>, GetListResponse<GetListOrderWasherListItemDto>>().ReverseMap();
    }
}