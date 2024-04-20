using Application.Features.AdvertSettings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AdvertSettings.Constants.AdvertSettingsOperationClaims;

namespace Application.Features.AdvertSettings.Queries.GetList;

public class GetListAdvertSettingQuery : IRequest<GetListResponse<GetListAdvertSettingListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListAdvertSettings({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetAdvertSettings";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAdvertSettingQueryHandler : IRequestHandler<GetListAdvertSettingQuery, GetListResponse<GetListAdvertSettingListItemDto>>
    {
        private readonly IAdvertSettingRepository _advertSettingRepository;
        private readonly IMapper _mapper;

        public GetListAdvertSettingQueryHandler(IAdvertSettingRepository advertSettingRepository, IMapper mapper)
        {
            _advertSettingRepository = advertSettingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdvertSettingListItemDto>> Handle(GetListAdvertSettingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AdvertSetting> advertSettings = await _advertSettingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAdvertSettingListItemDto> response = _mapper.Map<GetListResponse<GetListAdvertSettingListItemDto>>(advertSettings);
            return response;
        }
    }
}