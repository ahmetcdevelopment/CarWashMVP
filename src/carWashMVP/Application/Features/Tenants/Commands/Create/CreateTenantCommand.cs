using Application.Features.Tenants.Constants;
using Application.Features.Tenants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Tenants.Constants.TenantsOperationClaims;

namespace Application.Features.Tenants.Commands.Create;

public class CreateTenantCommand : IRequest<CreatedTenantResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Biography { get; set; }
    public Guid Slug { get; set; }
    public string TaxNumber { get; set; }
    public string Address { get; set; }

    public string[] Roles => [Admin, Write, TenantsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetTenants"];

    public class CreateTenantCommandHandler : IRequestHandler<CreateTenantCommand, CreatedTenantResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        private readonly TenantBusinessRules _tenantBusinessRules;

        public CreateTenantCommandHandler(IMapper mapper, ITenantRepository tenantRepository,
                                         TenantBusinessRules tenantBusinessRules)
        {
            _mapper = mapper;
            _tenantRepository = tenantRepository;
            _tenantBusinessRules = tenantBusinessRules;
        }

        public async Task<CreatedTenantResponse> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            Tenant tenant = _mapper.Map<Tenant>(request);

            await _tenantRepository.AddAsync(tenant);

            CreatedTenantResponse response = _mapper.Map<CreatedTenantResponse>(tenant);
            return response;
        }
    }
}