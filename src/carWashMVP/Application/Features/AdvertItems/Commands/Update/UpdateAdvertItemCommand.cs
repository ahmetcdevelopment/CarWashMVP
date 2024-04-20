using Application.Features.AdvertItems.Constants;
using Application.Features.AdvertItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.AdvertItems.Constants.AdvertItemsOperationClaims;

namespace Application.Features.AdvertItems.Commands.Update;

public class UpdateAdvertItemCommand : IRequest<UpdatedAdvertItemResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid AdvertId { get; set; }
    public AdvertItemCategory CategoryId { get; set; }
    public string Name { get; set; }
    public decimal AdditionalPrice { get; set; }

    public string[] Roles => [Admin, Write, AdvertItemsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdvertItems"];

    public class UpdateAdvertItemCommandHandler : IRequestHandler<UpdateAdvertItemCommand, UpdatedAdvertItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertItemRepository _advertItemRepository;
        private readonly AdvertItemBusinessRules _advertItemBusinessRules;

        public UpdateAdvertItemCommandHandler(IMapper mapper, IAdvertItemRepository advertItemRepository,
                                         AdvertItemBusinessRules advertItemBusinessRules)
        {
            _mapper = mapper;
            _advertItemRepository = advertItemRepository;
            _advertItemBusinessRules = advertItemBusinessRules;
        }

        public async Task<UpdatedAdvertItemResponse> Handle(UpdateAdvertItemCommand request, CancellationToken cancellationToken)
        {
            AdvertItem? advertItem = await _advertItemRepository.GetAsync(predicate: ai => ai.Id == request.Id, cancellationToken: cancellationToken);
            await _advertItemBusinessRules.AdvertItemShouldExistWhenSelected(advertItem);
            advertItem = _mapper.Map(request, advertItem);

            await _advertItemRepository.UpdateAsync(advertItem!);

            UpdatedAdvertItemResponse response = _mapper.Map<UpdatedAdvertItemResponse>(advertItem);
            return response;
        }
    }
}