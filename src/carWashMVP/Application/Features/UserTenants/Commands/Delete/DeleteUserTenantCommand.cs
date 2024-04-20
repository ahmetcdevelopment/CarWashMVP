using Application.Features.UserTenants.Constants;
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

namespace Application.Features.UserTenants.Commands.Delete;

public class DeleteUserTenantCommand : IRequest<DeletedUserTenantResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, UserTenantsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetUserTenants"];

    public class DeleteUserTenantCommandHandler : IRequestHandler<DeleteUserTenantCommand, DeletedUserTenantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserTenantRepository _userTenantRepository;
        private readonly UserTenantBusinessRules _userTenantBusinessRules;

        public DeleteUserTenantCommandHandler(IMapper mapper, IUserTenantRepository userTenantRepository,
                                         UserTenantBusinessRules userTenantBusinessRules)
        {
            _mapper = mapper;
            _userTenantRepository = userTenantRepository;
            _userTenantBusinessRules = userTenantBusinessRules;
        }

        public async Task<DeletedUserTenantResponse> Handle(DeleteUserTenantCommand request, CancellationToken cancellationToken)
        {
            UserTenant? userTenant = await _userTenantRepository.GetAsync(predicate: ut => ut.Id == request.Id, cancellationToken: cancellationToken);
            await _userTenantBusinessRules.UserTenantShouldExistWhenSelected(userTenant);

            await _userTenantRepository.DeleteAsync(userTenant!);

            DeletedUserTenantResponse response = _mapper.Map<DeletedUserTenantResponse>(userTenant);
            return response;
        }
    }
}