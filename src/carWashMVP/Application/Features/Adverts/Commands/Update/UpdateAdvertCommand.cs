using Application.Features.Adverts.Constants;
using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;

namespace Application.Features.Adverts.Commands.Update;

public class UpdateAdvertCommand : IRequest<UpdatedAdvertResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid WasherCarId { get; set; }
    public double Enlem { get; set; }
    public double Boylam { get; set; }
    public double Range { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public double PricePerDistance { get; set; }
    public double MinOrderAmount { get; set; }

    public string[] Roles => [Admin, Write, AdvertsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdverts"];

    public class UpdateAdvertCommandHandler : IRequestHandler<UpdateAdvertCommand, UpdatedAdvertResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertRepository _advertRepository;
        private readonly AdvertBusinessRules _advertBusinessRules;

        public UpdateAdvertCommandHandler(IMapper mapper, IAdvertRepository advertRepository,
                                         AdvertBusinessRules advertBusinessRules)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
            _advertBusinessRules = advertBusinessRules;
        }

        public async Task<UpdatedAdvertResponse> Handle(UpdateAdvertCommand request, CancellationToken cancellationToken)
        {
            Advert? advert = await _advertRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _advertBusinessRules.AdvertShouldExistWhenSelected(advert);
            advert = _mapper.Map(request, advert);

            await _advertRepository.UpdateAsync(advert!);

            UpdatedAdvertResponse response = _mapper.Map<UpdatedAdvertResponse>(advert);
            return response;
        }
    }
}