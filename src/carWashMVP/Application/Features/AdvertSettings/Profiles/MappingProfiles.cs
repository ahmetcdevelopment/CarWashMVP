using Application.Features.AdvertSettings.Commands.Create;
using Application.Features.AdvertSettings.Commands.Delete;
using Application.Features.AdvertSettings.Commands.Update;
using Application.Features.AdvertSettings.Queries.GetById;
using Application.Features.AdvertSettings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.AdvertSettings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AdvertSetting, CreateAdvertSettingCommand>().ReverseMap();
        CreateMap<AdvertSetting, CreatedAdvertSettingResponse>().ReverseMap();
        CreateMap<AdvertSetting, UpdateAdvertSettingCommand>().ReverseMap();
        CreateMap<AdvertSetting, UpdatedAdvertSettingResponse>().ReverseMap();
        CreateMap<AdvertSetting, DeleteAdvertSettingCommand>().ReverseMap();
        CreateMap<AdvertSetting, DeletedAdvertSettingResponse>().ReverseMap();
        CreateMap<AdvertSetting, GetByIdAdvertSettingResponse>().ReverseMap();
        CreateMap<AdvertSetting, GetListAdvertSettingListItemDto>().ReverseMap();
        CreateMap<IPaginate<AdvertSetting>, GetListResponse<GetListAdvertSettingListItemDto>>().ReverseMap();
    }
}