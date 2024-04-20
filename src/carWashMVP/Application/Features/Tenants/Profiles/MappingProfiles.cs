using Application.Features.Tenants.Commands.Create;
using Application.Features.Tenants.Commands.Delete;
using Application.Features.Tenants.Commands.Update;
using Application.Features.Tenants.Queries.GetById;
using Application.Features.Tenants.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Tenants.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Tenant, CreateTenantCommand>().ReverseMap();
        CreateMap<Tenant, CreatedTenantResponse>().ReverseMap();
        CreateMap<Tenant, UpdateTenantCommand>().ReverseMap();
        CreateMap<Tenant, UpdatedTenantResponse>().ReverseMap();
        CreateMap<Tenant, DeleteTenantCommand>().ReverseMap();
        CreateMap<Tenant, DeletedTenantResponse>().ReverseMap();
        CreateMap<Tenant, GetByIdTenantResponse>().ReverseMap();
        CreateMap<Tenant, GetListTenantListItemDto>().ReverseMap();
        CreateMap<IPaginate<Tenant>, GetListResponse<GetListTenantListItemDto>>().ReverseMap();
    }
}