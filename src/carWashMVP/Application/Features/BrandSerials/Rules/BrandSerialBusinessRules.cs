using Application.Features.BrandSerials.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.BrandSerials.Rules;

public class BrandSerialBusinessRules : BaseBusinessRules
{
    private readonly IBrandSerialRepository _brandSerialRepository;
    private readonly ILocalizationService _localizationService;

    public BrandSerialBusinessRules(IBrandSerialRepository brandSerialRepository, ILocalizationService localizationService)
    {
        _brandSerialRepository = brandSerialRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BrandSerialsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BrandSerialShouldExistWhenSelected(BrandSerial? brandSerial)
    {
        if (brandSerial == null)
            await throwBusinessException(BrandSerialsBusinessMessages.BrandSerialNotExists);
    }

    public async Task BrandSerialIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        BrandSerial? brandSerial = await _brandSerialRepository.GetAsync(
            predicate: bs => bs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BrandSerialShouldExistWhenSelected(brandSerial);
    }
}