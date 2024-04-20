using Application.Features.AdvertItems.Constants;
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
using static Application.Features.AdvertItems.Constants.AdvertItemsOperationClaims;

namespace Application.Features.AdvertItems.Commands.Delete;

public class DeleteAdvertItemCommand : IRequest<DeletedAdvertItemResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AdvertItemsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdvertItems"];

    public class DeleteAdvertItemCommandHandler : IRequestHandler<DeleteAdvertItemCommand, DeletedAdvertItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertItemRepository _advertItemRepository;
        private readonly AdvertItemBusinessRules _advertItemBusinessRules;

        public DeleteAdvertItemCommandHandler(IMapper mapper, IAdvertItemRepository advertItemRepository,
                                         AdvertItemBusinessRules advertItemBusinessRules)
        {
            _mapper = mapper;
            _advertItemRepository = advertItemRepository;
            _advertItemBusinessRules = advertItemBusinessRules;
        }

        public async Task<DeletedAdvertItemResponse> Handle(DeleteAdvertItemCommand request, CancellationToken cancellationToken)
        {
            AdvertItem? advertItem = await _advertItemRepository.GetAsync(predicate: ai => ai.Id == request.Id, cancellationToken: cancellationToken);
            await _advertItemBusinessRules.AdvertItemShouldExistWhenSelected(advertItem);

            await _advertItemRepository.DeleteAsync(advertItem!);

            DeletedAdvertItemResponse response = _mapper.Map<DeletedAdvertItemResponse>(advertItem);
            return response;
        }
    }
}