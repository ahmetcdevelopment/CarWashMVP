using Application.Features.BrandSerials.Constants;
using Application.Features.BrandSerials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BrandSerials.Constants.BrandSerialsOperationClaims;

namespace Application.Features.BrandSerials.Queries.GetById;

public class GetByIdBrandSerialQuery : IRequest<GetByIdBrandSerialResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBrandSerialQueryHandler : IRequestHandler<GetByIdBrandSerialQuery, GetByIdBrandSerialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandSerialRepository _brandSerialRepository;
        private readonly BrandSerialBusinessRules _brandSerialBusinessRules;

        public GetByIdBrandSerialQueryHandler(IMapper mapper, IBrandSerialRepository brandSerialRepository, BrandSerialBusinessRules brandSerialBusinessRules)
        {
            _mapper = mapper;
            _brandSerialRepository = brandSerialRepository;
            _brandSerialBusinessRules = brandSerialBusinessRules;
        }

        public async Task<GetByIdBrandSerialResponse> Handle(GetByIdBrandSerialQuery request, CancellationToken cancellationToken)
        {
            BrandSerial? brandSerial = await _brandSerialRepository.GetAsync(predicate: bs => bs.Id == request.Id, cancellationToken: cancellationToken);
            await _brandSerialBusinessRules.BrandSerialShouldExistWhenSelected(brandSerial);

            GetByIdBrandSerialResponse response = _mapper.Map<GetByIdBrandSerialResponse>(brandSerial);
            return response;
        }
    }
}