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

namespace Application.Features.BrandSerials.Commands.Update;

public class UpdateBrandSerialCommand : IRequest<UpdatedBrandSerialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid ParentId { get; set; }
    public int? Depth { get; set; }
    public CaseType CaseType { get; set; }
    public string Name { get; set; }

    public string[] Roles => [Admin, Write, BrandSerialsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBrandSerials"];

    public class UpdateBrandSerialCommandHandler : IRequestHandler<UpdateBrandSerialCommand, UpdatedBrandSerialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandSerialRepository _brandSerialRepository;
        private readonly BrandSerialBusinessRules _brandSerialBusinessRules;

        public UpdateBrandSerialCommandHandler(IMapper mapper, IBrandSerialRepository brandSerialRepository,
                                         BrandSerialBusinessRules brandSerialBusinessRules)
        {
            _mapper = mapper;
            _brandSerialRepository = brandSerialRepository;
            _brandSerialBusinessRules = brandSerialBusinessRules;
        }

        public async Task<UpdatedBrandSerialResponse> Handle(UpdateBrandSerialCommand request, CancellationToken cancellationToken)
        {
            BrandSerial? brandSerial = await _brandSerialRepository.GetAsync(predicate: bs => bs.Id == request.Id, cancellationToken: cancellationToken);
            await _brandSerialBusinessRules.BrandSerialShouldExistWhenSelected(brandSerial);
            brandSerial = _mapper.Map(request, brandSerial);

            await _brandSerialRepository.UpdateAsync(brandSerial!);

            UpdatedBrandSerialResponse response = _mapper.Map<UpdatedBrandSerialResponse>(brandSerial);
            return response;
        }
    }
}