using Application.Features.AdvertItems.Constants;
using Application.Features.AdvertItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AdvertItems.Constants.AdvertItemsOperationClaims;

namespace Application.Features.AdvertItems.Queries.GetById;

public class GetByIdAdvertItemQuery : IRequest<GetByIdAdvertItemResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAdvertItemQueryHandler : IRequestHandler<GetByIdAdvertItemQuery, GetByIdAdvertItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertItemRepository _advertItemRepository;
        private readonly AdvertItemBusinessRules _advertItemBusinessRules;

        public GetByIdAdvertItemQueryHandler(IMapper mapper, IAdvertItemRepository advertItemRepository, AdvertItemBusinessRules advertItemBusinessRules)
        {
            _mapper = mapper;
            _advertItemRepository = advertItemRepository;
            _advertItemBusinessRules = advertItemBusinessRules;
        }

        public async Task<GetByIdAdvertItemResponse> Handle(GetByIdAdvertItemQuery request, CancellationToken cancellationToken)
        {
            AdvertItem? advertItem = await _advertItemRepository.GetAsync(predicate: ai => ai.Id == request.Id, cancellationToken: cancellationToken);
            await _advertItemBusinessRules.AdvertItemShouldExistWhenSelected(advertItem);

            GetByIdAdvertItemResponse response = _mapper.Map<GetByIdAdvertItemResponse>(advertItem);
            return response;
        }
    }
}