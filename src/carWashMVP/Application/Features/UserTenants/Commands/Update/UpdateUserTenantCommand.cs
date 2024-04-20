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

namespace Application.Features.UserTenants.Commands.Update;

public class UpdateUserTenantCommand : IRequest<UpdatedUserTenantResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }

    public string[] Roles => [Admin, Write, UserTenantsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserTenants"];

    public class UpdateUserTenantCommandHandler : IRequestHandler<UpdateUserTenantCommand, UpdatedUserTenantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserTenantRepository _userTenantRepository;
        private readonly UserTenantBusinessRules _userTenantBusinessRules;

        public UpdateUserTenantCommandHandler(IMapper mapper, IUserTenantRepository userTenantRepository,
                                         UserTenantBusinessRules userTenantBusinessRules)
        {
            _mapper = mapper;
            _userTenantRepository = userTenantRepository;
            _userTenantBusinessRules = userTenantBusinessRules;
        }

        public async Task<UpdatedUserTenantResponse> Handle(UpdateUserTenantCommand request, CancellationToken cancellationToken)
        {
            UserTenant? userTenant = await _userTenantRepository.GetAsync(predicate: ut => ut.Id == request.Id, cancellationToken: cancellationToken);
            await _userTenantBusinessRules.UserTenantShouldExistWhenSelected(userTenant);
            userTenant = _mapper.Map(request, userTenant);

            await _userTenantRepository.UpdateAsync(userTenant!);

            UpdatedUserTenantResponse response = _mapper.Map<UpdatedUserTenantResponse>(userTenant);
            return response;
        }
    }
}