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

namespace Application.Features.OrderWashers.Commands.Update;

public class UpdateOrderWasherCommand : IRequest<UpdatedOrderWasherResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }
    public Guid WasherUserId { get; set; }

    public string[] Roles => [Admin, Write, OrderWashersOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderWashers"];

    public class UpdateOrderWasherCommandHandler : IRequestHandler<UpdateOrderWasherCommand, UpdatedOrderWasherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderWasherRepository _orderWasherRepository;
        private readonly OrderWasherBusinessRules _orderWasherBusinessRules;

        public UpdateOrderWasherCommandHandler(IMapper mapper, IOrderWasherRepository orderWasherRepository,
                                         OrderWasherBusinessRules orderWasherBusinessRules)
        {
            _mapper = mapper;
            _orderWasherRepository = orderWasherRepository;
            _orderWasherBusinessRules = orderWasherBusinessRules;
        }

        public async Task<UpdatedOrderWasherResponse> Handle(UpdateOrderWasherCommand request, CancellationToken cancellationToken)
        {
            OrderWasher? orderWasher = await _orderWasherRepository.GetAsync(predicate: ow => ow.Id == request.Id, cancellationToken: cancellationToken);
            await _orderWasherBusinessRules.OrderWasherShouldExistWhenSelected(orderWasher);
            orderWasher = _mapper.Map(request, orderWasher);

            await _orderWasherRepository.UpdateAsync(orderWasher!);

            UpdatedOrderWasherResponse response = _mapper.Map<UpdatedOrderWasherResponse>(orderWasher);
            return response;
        }
    }
}