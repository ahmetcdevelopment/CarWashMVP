using Application.Features.OrderWashers.Constants;
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

namespace Application.Features.OrderWashers.Commands.Delete;

public class DeleteOrderWasherCommand : IRequest<DeletedOrderWasherResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, OrderWashersOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetOrderWashers"];

    public class DeleteOrderWasherCommandHandler : IRequestHandler<DeleteOrderWasherCommand, DeletedOrderWasherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderWasherRepository _orderWasherRepository;
        private readonly OrderWasherBusinessRules _orderWasherBusinessRules;

        public DeleteOrderWasherCommandHandler(IMapper mapper, IOrderWasherRepository orderWasherRepository,
                                         OrderWasherBusinessRules orderWasherBusinessRules)
        {
            _mapper = mapper;
            _orderWasherRepository = orderWasherRepository;
            _orderWasherBusinessRules = orderWasherBusinessRules;
        }

        public async Task<DeletedOrderWasherResponse> Handle(DeleteOrderWasherCommand request, CancellationToken cancellationToken)
        {
            OrderWasher? orderWasher = await _orderWasherRepository.GetAsync(predicate: ow => ow.Id == request.Id, cancellationToken: cancellationToken);
            await _orderWasherBusinessRules.OrderWasherShouldExistWhenSelected(orderWasher);

            await _orderWasherRepository.DeleteAsync(orderWasher!);

            DeletedOrderWasherResponse response = _mapper.Map<DeletedOrderWasherResponse>(orderWasher);
            return response;
        }
    }
}