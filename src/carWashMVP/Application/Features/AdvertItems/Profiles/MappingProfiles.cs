using Application.Features.AdvertItems.Commands.Create;
using Application.Features.AdvertItems.Commands.Delete;
using Application.Features.AdvertItems.Commands.Update;
using Application.Features.AdvertItems.Queries.GetById;
using Application.Features.AdvertItems.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AdvertItems.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AdvertItem, CreateAdvertItemCommand>().ReverseMap();
        CreateMap<AdvertItem, CreatedAdvertItemResponse>().ReverseMap();
        CreateMap<AdvertItem, UpdateAdvertItemCommand>().ReverseMap();
        CreateMap<AdvertItem, UpdatedAdvertItemResponse>().ReverseMap();
        CreateMap<AdvertItem, DeleteAdvertItemCommand>().ReverseMap();
        CreateMap<AdvertItem, DeletedAdvertItemResponse>().ReverseMap();
        CreateMap<AdvertItem, GetByIdAdvertItemResponse>().ReverseMap();
        CreateMap<AdvertItem, GetListAdvertItemListItemDto>().ReverseMap();
        CreateMap<IPaginate<AdvertItem>, GetListResponse<GetListAdvertItemListItemDto>>().ReverseMap();
    }
}