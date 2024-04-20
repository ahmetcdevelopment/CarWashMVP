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

namespace Application.Features.AdvertItems.Commands.Create;

public class CreateAdvertItemCommand : IRequest<CreatedAdvertItemResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid TenantId { get; set; }
    public Guid AdvertId { get; set; }
    public AdvertItemCategory CategoryId { get; set; }
    public string Name { get; set; }
    public decimal AdditionalPrice { get; set; }

    public string[] Roles => [Admin, Write, AdvertItemsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdvertItems"];

    public class CreateAdvertItemCommandHandler : IRequestHandler<CreateAdvertItemCommand, CreatedAdvertItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertItemRepository _advertItemRepository;
        private readonly AdvertItemBusinessRules _advertItemBusinessRules;

        public CreateAdvertItemCommandHandler(IMapper mapper, IAdvertItemRepository advertItemRepository,
                                         AdvertItemBusinessRules advertItemBusinessRules)
        {
            _mapper = mapper;
            _advertItemRepository = advertItemRepository;
            _advertItemBusinessRules = advertItemBusinessRules;
        }

        public async Task<CreatedAdvertItemResponse> Handle(CreateAdvertItemCommand request, CancellationToken cancellationToken)
        {
            AdvertItem advertItem = _mapper.Map<AdvertItem>(request);

            await _advertItemRepository.AddAsync(advertItem);

            CreatedAdvertItemResponse response = _mapper.Map<CreatedAdvertItemResponse>(advertItem);
            return response;
        }
    }
}