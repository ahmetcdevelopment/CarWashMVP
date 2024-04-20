using Application.Features.UserTenants.Constants;
using Application.Features.UserTenants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.UserTenants.Constants.UserTenantsOperationClaims;

namespace Application.Features.UserTenants.Queries.GetById;

public class GetByIdUserTenantQuery : IRequest<GetByIdUserTenantResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdUserTenantQueryHandler : IRequestHandler<GetByIdUserTenantQuery, GetByIdUserTenantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserTenantRepository _userTenantRepository;
        private readonly UserTenantBusinessRules _userTenantBusinessRules;

        public GetByIdUserTenantQueryHandler(IMapper mapper, IUserTenantRepository userTenantRepository, UserTenantBusinessRules userTenantBusinessRules)
        {
            _mapper = mapper;
            _userTenantRepository = userTenantRepository;
            _userTenantBusinessRules = userTenantBusinessRules;
        }

        public async Task<GetByIdUserTenantResponse> Handle(GetByIdUserTenantQuery request, CancellationToken cancellationToken)
        {
            UserTenant? userTenant = await _userTenantRepository.GetAsync(predicate: ut => ut.Id == request.Id, cancellationToken: cancellationToken);
            await _userTenantBusinessRules.UserTenantShouldExistWhenSelected(userTenant);

            GetByIdUserTenantResponse response = _mapper.Map<GetByIdUserTenantResponse>(userTenant);
            return response;
        }
    }
}