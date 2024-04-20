using Application.Features.Adverts.Commands.Create;
using Application.Features.Adverts.Commands.Delete;
using Application.Features.Adverts.Commands.Update;
using Application.Features.Adverts.Queries.GetById;
using Application.Features.Adverts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Adverts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Advert, CreateAdvertCommand>().ReverseMap();
        CreateMap<Advert, CreatedAdvertResponse>().ReverseMap();
        CreateMap<Advert, UpdateAdvertCommand>().ReverseMap();
        CreateMap<Advert, UpdatedAdvertResponse>().ReverseMap();
        CreateMap<Advert, DeleteAdvertCommand>().ReverseMap();
        CreateMap<Advert, DeletedAdvertResponse>().ReverseMap();
        CreateMap<Advert, GetByIdAdvertResponse>().ReverseMap();
        CreateMap<Advert, GetListAdvertListItemDto>().ReverseMap();
        CreateMap<IPaginate<Advert>, GetListResponse<GetListAdvertListItemDto>>().ReverseMap();
    }
}