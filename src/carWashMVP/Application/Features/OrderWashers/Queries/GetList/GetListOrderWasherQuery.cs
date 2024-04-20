using Application.Features.OrderWashers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.OrderWashers.Constants.OrderWashersOperationClaims;

namespace Application.Features.OrderWashers.Queries.GetList;

public class GetListOrderWasherQuery : IRequest<GetListResponse<GetListOrderWasherListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListOrderWashers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetOrderWashers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListOrderWasherQueryHandler : IRequestHandler<GetListOrderWasherQuery, GetListResponse<GetListOrderWasherListItemDto>>
    {
        private readonly IOrderWasherRepository _orderWasherRepository;
        private readonly IMapper _mapper;

        public GetListOrderWasherQueryHandler(IOrderWasherRepository orderWasherRepository, IMapper mapper)
        {
            _orderWasherRepository = orderWasherRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderWasherListItemDto>> Handle(GetListOrderWasherQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OrderWasher> orderWashers = await _orderWasherRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrderWasherListItemDto> response = _mapper.Map<GetListResponse<GetListOrderWasherListItemDto>>(orderWashers);
            return response;
        }
    }
}