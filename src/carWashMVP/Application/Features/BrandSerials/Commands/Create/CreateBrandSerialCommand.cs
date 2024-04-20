using Application.Features.BrandSerials.Constants;
using Application.Features.BrandSerials.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using static Application.Features.BrandSerials.Constants.BrandSerialsOperationClaims;

namespace Application.Features.BrandSerials.Commands.Create;

public class CreateBrandSerialCommand : IRequest<CreatedBrandSerialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid ParentId { get; set; }
    public int? Depth { get; set; }
    public CaseType CaseType { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, BrandSerialsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBrandSerials"];

    public class CreateBrandSerialCommandHandler : IRequestHandler<CreateBrandSerialCommand, CreatedBrandSerialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandSerialRepository _brandSerialRepository;
        private readonly BrandSerialBusinessRules _brandSerialBusinessRules;

        public CreateBrandSerialCommandHandler(IMapper mapper, IBrandSerialRepository brandSerialRepository,
                                         BrandSerialBusinessRules brandSerialBusinessRules)
        {
            _mapper = mapper;
            _brandSerialRepository = brandSerialRepository;
            _brandSerialBusinessRules = brandSerialBusinessRules;
        }

        public async Task<CreatedBrandSerialResponse> Handle(CreateBrandSerialCommand request, CancellationToken cancellationToken)
        {
            BrandSerial brandSerial = _mapper.Map<BrandSerial>(request);

            await _brandSerialRepository.AddAsync(brandSerial);

            CreatedBrandSerialResponse response = _mapper.Map<CreatedBrandSerialResponse>(brandSerial);
            return response;
        }
    }
}