using Application.Features.UserTenants.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserTenants.Rules;

public class UserTenantBusinessRules : BaseBusinessRules
{
    private readonly IUserTenantRepository _userTenantRepository;
    private readonly ILocalizationService _localizationService;

    public UserTenantBusinessRules(IUserTenantRepository userTenantRepository, ILocalizationService localizationService)
    {
        _userTenantRepository = userTenantRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserTenantsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserTenantShouldExistWhenSelected(UserTenant? userTenant)
    {
        if (userTenant == null)
            await throwBusinessException(UserTenantsBusinessMessages.UserTenantNotExists);
    }

    public async Task UserTenantIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserTenant? userTenant = await _userTenantRepository.GetAsync(
            predicate: ut => ut.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserTenantShouldExistWhenSelected(userTenant);
    }
}