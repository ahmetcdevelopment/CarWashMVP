using Application.Features.OrderWashers.Constants;
using Application.Features.OrderWashers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.OrderWashers.Constants.OrderWashersOperationClaims;

namespace Application.Features.OrderWashers.Commands.Create;

public class CreateOrderWasherCommand : IRequest<CreatedOrderWasherResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }
    public Guid WasherUserId { get; set; }

    public string[] Roles => [Admin, Write, OrderWashersOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderWashers"];

    public class CreateOrderWasherCommandHandler : IRequestHandler<CreateOrderWasherCommand, CreatedOrderWasherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderWasherRepository _orderWasherRepository;
        private readonly OrderWasherBusinessRules _orderWasherBusinessRules;

        public CreateOrderWasherCommandHandler(IMapper mapper, IOrderWasherRepository orderWasherRepository,
                                         OrderWasherBusinessRules orderWasherBusinessRules)
        {
            _mapper = mapper;
            _orderWasherRepository = orderWasherRepository;
            _orderWasherBusinessRules = orderWasherBusinessRules;
        }

        public async Task<CreatedOrderWasherResponse> Handle(CreateOrderWasherCommand request, CancellationToken cancellationToken)
        {
            OrderWasher orderWasher = _mapper.Map<OrderWasher>(request);

            await _orderWasherRepository.AddAsync(orderWasher);

            CreatedOrderWasherResponse response = _mapper.Map<CreatedOrderWasherResponse>(orderWasher);
            return response;
        }
    }
}