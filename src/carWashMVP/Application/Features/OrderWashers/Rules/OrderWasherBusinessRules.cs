using Application.Features.OrderWashers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.OrderWashers.Rules;

public class OrderWasherBusinessRules : BaseBusinessRules
{
    private readonly IOrderWasherRepository _orderWasherRepository;
    private readonly ILocalizationService _localizationService;

    public OrderWasherBusinessRules(IOrderWasherRepository orderWasherRepository, ILocalizationService localizationService)
    {
        _orderWasherRepository = orderWasherRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OrderWashersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OrderWasherShouldExistWhenSelected(OrderWasher? orderWasher)
    {
        if (orderWasher == null)
            await throwBusinessException(OrderWashersBusinessMessages.OrderWasherNotExists);
    }

    public async Task OrderWasherIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        OrderWasher? orderWasher = await _orderWasherRepository.GetAsync(
            predicate: ow => ow.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OrderWasherShouldExistWhenSelected(orderWasher);
    }
}