using Application.Features.UserTenants.Commands.Create;
using Application.Features.UserTenants.Commands.Delete;
using Application.Features.UserTenants.Commands.Update;
using Application.Features.UserTenants.Queries.GetById;
using Application.Features.UserTenants.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserTenants.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserTenant, CreateUserTenantCommand>().ReverseMap();
        CreateMap<UserTenant, CreatedUserTenantResponse>().ReverseMap();
        CreateMap<UserTenant, UpdateUserTenantCommand>().ReverseMap();
        CreateMap<UserTenant, UpdatedUserTenantResponse>().ReverseMap();
        CreateMap<UserTenant, DeleteUserTenantCommand>().ReverseMap();
        CreateMap<UserTenant, DeletedUserTenantResponse>().ReverseMap();
        CreateMap<UserTenant, GetByIdUserTenantResponse>().ReverseMap();
        CreateMap<UserTenant, GetListUserTenantListItemDto>().ReverseMap();
        CreateMap<IPaginate<UserTenant>, GetListResponse<GetListUserTenantListItemDto>>().ReverseMap();
    }
}