using Application.Features.BrandSerials.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BrandSerials.Constants.BrandSerialsOperationClaims;

namespace Application.Features.BrandSerials.Queries.GetList;

public class GetListBrandSerialQuery : IRequest<GetListResponse<GetListBrandSerialListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBrandSerials({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBrandSerials";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBrandSerialQueryHandler : IRequestHandler<GetListBrandSerialQuery, GetListResponse<GetListBrandSerialListItemDto>>
    {
        private readonly IBrandSerialRepository _brandSerialRepository;
        private readonly IMapper _mapper;

        public GetListBrandSerialQueryHandler(IBrandSerialRepository brandSerialRepository, IMapper mapper)
        {
            _brandSerialRepository = brandSerialRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBrandSerialListItemDto>> Handle(GetListBrandSerialQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BrandSerial> brandSerials = await _brandSerialRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBrandSerialListItemDto> response = _mapper.Map<GetListResponse<GetListBrandSerialListItemDto>>(brandSerials);
            return response;
        }
    }
}