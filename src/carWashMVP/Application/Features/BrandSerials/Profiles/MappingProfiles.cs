using Application.Features.BrandSerials.Commands.Create;
using Application.Features.BrandSerials.Commands.Delete;
using Application.Features.BrandSerials.Commands.Update;
using Application.Features.BrandSerials.Queries.GetById;
using Application.Features.BrandSerials.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.BrandSerials.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BrandSerial, CreateBrandSerialCommand>().ReverseMap();
        CreateMap<BrandSerial, CreatedBrandSerialResponse>().ReverseMap();
        CreateMap<BrandSerial, UpdateBrandSerialCommand>().ReverseMap();
        CreateMap<BrandSerial, UpdatedBrandSerialResponse>().ReverseMap();
        CreateMap<BrandSerial, DeleteBrandSerialCommand>().ReverseMap();
        CreateMap<BrandSerial, DeletedBrandSerialResponse>().ReverseMap();
        CreateMap<BrandSerial, GetByIdBrandSerialResponse>().ReverseMap();
        CreateMap<BrandSerial, GetListBrandSerialListItemDto>().ReverseMap();
        CreateMap<IPaginate<BrandSerial>, GetListResponse<GetListBrandSerialListItemDto>>().ReverseMap();
    }
}