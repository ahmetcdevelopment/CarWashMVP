using Application.Features.BrandSerials.Constants;
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
using static Application.Features.BrandSerials.Constants.BrandSerialsOperationClaims;

namespace Application.Features.BrandSerials.Commands.Delete;

public class DeleteBrandSerialCommand : IRequest<DeletedBrandSerialResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, BrandSerialsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBrandSerials"];

    public class DeleteBrandSerialCommandHandler : IRequestHandler<DeleteBrandSerialCommand, DeletedBrandSerialResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandSerialRepository _brandSerialRepository;
        private readonly BrandSerialBusinessRules _brandSerialBusinessRules;

        public DeleteBrandSerialCommandHandler(IMapper mapper, IBrandSerialRepository brandSerialRepository,
                                         BrandSerialBusinessRules brandSerialBusinessRules)
        {
            _mapper = mapper;
            _brandSerialRepository = brandSerialRepository;
            _brandSerialBusinessRules = brandSerialBusinessRules;
        }

        public async Task<DeletedBrandSerialResponse> Handle(DeleteBrandSerialCommand request, CancellationToken cancellationToken)
        {
            BrandSerial? brandSerial = await _brandSerialRepository.GetAsync(predicate: bs => bs.Id == request.Id, cancellationToken: cancellationToken);
            await _brandSerialBusinessRules.BrandSerialShouldExistWhenSelected(brandSerial);

            await _brandSerialRepository.DeleteAsync(brandSerial!);

            DeletedBrandSerialResponse response = _mapper.Map<DeletedBrandSerialResponse>(brandSerial);
            return response;
        }
    }
}