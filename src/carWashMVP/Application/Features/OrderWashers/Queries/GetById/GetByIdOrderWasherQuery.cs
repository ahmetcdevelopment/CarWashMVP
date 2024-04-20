using Application.Features.OrderWashers.Constants;
using Application.Features.OrderWashers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.OrderWashers.Constants.OrderWashersOperationClaims;

namespace Application.Features.OrderWashers.Queries.GetById;

public class GetByIdOrderWasherQuery : IRequest<GetByIdOrderWasherResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdOrderWasherQueryHandler : IRequestHandler<GetByIdOrderWasherQuery, GetByIdOrderWasherResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderWasherRepository _orderWasherRepository;
        private readonly OrderWasherBusinessRules _orderWasherBusinessRules;

        public GetByIdOrderWasherQueryHandler(IMapper mapper, IOrderWasherRepository orderWasherRepository, OrderWasherBusinessRules orderWasherBusinessRules)
        {
            _mapper = mapper;
            _orderWasherRepository = orderWasherRepository;
            _orderWasherBusinessRules = orderWasherBusinessRules;
        }

        public async Task<GetByIdOrderWasherResponse> Handle(GetByIdOrderWasherQuery request, CancellationToken cancellationToken)
        {
            OrderWasher? orderWasher = await _orderWasherRepository.GetAsync(predicate: ow => ow.Id == request.Id, cancellationToken: cancellationToken);
            await _orderWasherBusinessRules.OrderWasherShouldExistWhenSelected(orderWasher);

            GetByIdOrderWasherResponse response = _mapper.Map<GetByIdOrderWasherResponse>(orderWasher);
            return response;
        }
    }
}