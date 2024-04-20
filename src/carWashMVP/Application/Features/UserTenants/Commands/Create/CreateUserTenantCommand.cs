using Application.Features.UserTenants.Constants;
using Application.Features.UserTenants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.UserTenants.Constants.UserTenantsOperationClaims;

namespace Application.Features.UserTenants.Commands.Create;

public class CreateUserTenantCommand : IRequest<CreatedUserTenantResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }

    public string[] Roles => [Admin, Write, UserTenantsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserTenants"];

    public class CreateUserTenantCommandHandler : IRequestHandler<CreateUserTenantCommand, CreatedUserTenantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserTenantRepository _userTenantRepository;
        private readonly UserTenantBusinessRules _userTenantBusinessRules;

        public CreateUserTenantCommandHandler(IMapper mapper, IUserTenantRepository userTenantRepository,
                                         UserTenantBusinessRules userTenantBusinessRules)
        {
            _mapper = mapper;
            _userTenantRepository = userTenantRepository;
            _userTenantBusinessRules = userTenantBusinessRules;
        }

        public async Task<CreatedUserTenantResponse> Handle(CreateUserTenantCommand request, CancellationToken cancellationToken)
        {
            UserTenant userTenant = _mapper.Map<UserTenant>(request);

            await _userTenantRepository.AddAsync(userTenant);

            CreatedUserTenantResponse response = _mapper.Map<CreatedUserTenantResponse>(userTenant);
            return response;
        }
    }
}