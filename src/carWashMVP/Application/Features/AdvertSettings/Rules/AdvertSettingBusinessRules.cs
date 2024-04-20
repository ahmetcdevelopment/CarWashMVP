using Application.Features.AdvertSettings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AdvertSettings.Rules;

public class AdvertSettingBusinessRules : BaseBusinessRules
{
    private readonly IAdvertSettingRepository _advertSettingRepository;
    private readonly ILocalizationService _localizationService;

    public AdvertSettingBusinessRules(IAdvertSettingRepository advertSettingRepository, ILocalizationService localizationService)
    {
        _advertSettingRepository = advertSettingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdvertSettingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdvertSettingShouldExistWhenSelected(AdvertSetting? advertSetting)
    {
        if (advertSetting == null)
            await throwBusinessException(AdvertSettingsBusinessMessages.AdvertSettingNotExists);
    }

    public async Task AdvertSettingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AdvertSetting? advertSetting = await _advertSettingRepository.GetAsync(
            predicate: ads => ads.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdvertSettingShouldExistWhenSelected(advertSetting);
    }
}