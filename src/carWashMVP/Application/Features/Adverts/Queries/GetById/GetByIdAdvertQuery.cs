using Application.Features.Adverts.Constants;
using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;

namespace Application.Features.Adverts.Queries.GetById;

public class GetByIdAdvertQuery : IRequest<GetByIdAdvertResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAdvertQueryHandler : IRequestHandler<GetByIdAdvertQuery, GetByIdAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertRepository _advertRepository;
        private readonly AdvertBusinessRules _advertBusinessRules;

        public GetByIdAdvertQueryHandler(IMapper mapper, IAdvertRepository advertRepository, AdvertBusinessRules advertBusinessRules)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
            _advertBusinessRules = advertBusinessRules;
        }

        public async Task<GetByIdAdvertResponse> Handle(GetByIdAdvertQuery request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _advertBusinessRules.AdvertShouldExistWhenSelected(advert);

            GetByIdAdvertResponse response = _mapper.Map<GetByIdAdvertResponse>(advert);
            return response;
        }
    }
}