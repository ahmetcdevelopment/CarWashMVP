using Application.Features.Adverts.Commands.Create;
using Application.Features.Adverts.Constants;
using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Adverts.Constants.AdvertsOperationClaims;


namespace Application.Features.Adverts.Commands.CreateWithAdvertItems;
//ITransactionalRequest sınıfını implement eden sınıf TransactionalBehaviour<>
//Yazılan Handle methodu bu transaction içerisinde çalışıyor.
public class CreateWithAdvertItemsCommand : IRequest<CreatedWithAdvertItemsResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid TenantId { get; set; }
    public Guid WasherCarId { get; set; }
    public double Enlem { get; set; }
    public double Boylam { get; set; }
    public double Range { get; set; }
    public decimal Price { get; set; }
    public string Title { get; set; }
    public double PricePerDistance { get; set; }
    public double MinOrderAmount { get; set; }

    public string[] Roles => [Admin, Write, AdvertsOperationClaims.Create];

    public bool BypassCache { get; }

    public string? CacheKey { get; }

    public string[]? CacheGroupKey => ["GetAdverts"];
    public class CreateAdvertCommandHandler : IRequestHandler<CreateWithAdvertItemsCommand, CreatedWithAdvertItemsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertRepository _advertRepository;
        private readonly AdvertBusinessRules _advertBusinessRules;
        private readonly IAdvertItemRepository _advertItemRepository;
        public CreateAdvertCommandHandler(IMapper mapper, IAdvertRepository advertRepository,
            AdvertBusinessRules advertBusinessRules, IAdvertItemRepository advertItemRepository)
        {
            _mapper = mapper;
            _advertRepository = advertRepository;
            _advertBusinessRules = advertBusinessRules;
            _advertItemRepository = advertItemRepository;
        }

        public async Task<CreatedWithAdvertItemsResponse> Handle(CreateWithAdvertItemsCommand request, CancellationToken cancellationToken)
        {
            var advert = _mapper.Map<Advert>(request);

            await _advertRepository.AddAsync(advert);

            if (advert.AdvertItems.Any())
            {
                await _advertItemRepository.AddRangeAsync(advert.AdvertItems);
            }
            var response = _mapper.Map<CreatedWithAdvertItemsResponse>(advert);
            return response;
        }
    }
}
