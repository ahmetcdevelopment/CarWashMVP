using Application.Features.AdvertItems.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AdvertItems.Constants.AdvertItemsOperationClaims;

namespace Application.Features.AdvertItems.Queries.GetList;

public class GetListAdvertItemQuery : IRequest<GetListResponse<GetListAdvertItemListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListAdvertItems({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetAdvertItems";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAdvertItemQueryHandler : IRequestHandler<GetListAdvertItemQuery, GetListResponse<GetListAdvertItemListItemDto>>
    {
        private readonly IAdvertItemRepository _advertItemRepository;
        private readonly IMapper _mapper;

        public GetListAdvertItemQueryHandler(IAdvertItemRepository advertItemRepository, IMapper mapper)
        {
            _advertItemRepository = advertItemRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdvertItemListItemDto>> Handle(GetListAdvertItemQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AdvertItem> advertItems = await _advertItemRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAdvertItemListItemDto> response = _mapper.Map<GetListResponse<GetListAdvertItemListItemDto>>(advertItems);
            return response;
        }
    }
}