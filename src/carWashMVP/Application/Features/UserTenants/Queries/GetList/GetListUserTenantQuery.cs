using Application.Features.UserTenants.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.UserTenants.Constants.UserTenantsOperationClaims;

namespace Application.Features.UserTenants.Queries.GetList;

public class GetListUserTenantQuery : IRequest<GetListResponse<GetListUserTenantListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListUserTenants({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetUserTenants";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListUserTenantQueryHandler : IRequestHandler<GetListUserTenantQuery, GetListResponse<GetListUserTenantListItemDto>>
    {
        private readonly IUserTenantRepository _userTenantRepository;
        private readonly IMapper _mapper;

        public GetListUserTenantQueryHandler(IUserTenantRepository userTenantRepository, IMapper mapper)
        {
            _userTenantRepository = userTenantRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserTenantListItemDto>> Handle(GetListUserTenantQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserTenant> userTenants = await _userTenantRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserTenantListItemDto> response = _mapper.Map<GetListResponse<GetListUserTenantListItemDto>>(userTenants);
            return response;
        }
    }
}