using Application.Features.AdvertItems.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AdvertItems.Rules;

public class AdvertItemBusinessRules : BaseBusinessRules
{
    private readonly IAdvertItemRepository _advertItemRepository;
    private readonly ILocalizationService _localizationService;

    public AdvertItemBusinessRules(IAdvertItemRepository advertItemRepository, ILocalizationService localizationService)
    {
        _advertItemRepository = advertItemRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdvertItemsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdvertItemShouldExistWhenSelected(AdvertItem? advertItem)
    {
        if (advertItem == null)
            await throwBusinessException(AdvertItemsBusinessMessages.AdvertItemNotExists);
    }

    public async Task AdvertItemIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AdvertItem? advertItem = await _advertItemRepository.GetAsync(
            predicate: ai => ai.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdvertItemShouldExistWhenSelected(advertItem);
    }
}