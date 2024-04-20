using Application.Features.Adverts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Adverts.Rules;

public class AdvertBusinessRules : BaseBusinessRules
{
    private readonly IAdvertRepository _advertRepository;
    private readonly ILocalizationService _localizationService;

    public AdvertBusinessRules(IAdvertRepository advertRepository, ILocalizationService localizationService)
    {
        _advertRepository = advertRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdvertsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdvertShouldExistWhenSelected(Advert? advert)
    {
        if (advert == null)
            await throwBusinessException(AdvertsBusinessMessages.AdvertNotExists);
    }

    public async Task AdvertIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Advert? advert = await _advertRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdvertShouldExistWhenSelected(advert);
    }
}