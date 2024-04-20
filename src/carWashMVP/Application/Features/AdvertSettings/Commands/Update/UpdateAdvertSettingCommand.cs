using Application.Features.AdvertSettings.Constants;
using Application.Features.AdvertSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AdvertSettings.Constants.AdvertSettingsOperationClaims;

namespace Application.Features.AdvertSettings.Commands.Update;

public class UpdateAdvertSettingCommand : IRequest<UpdatedAdvertSettingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public int DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public string[] Roles => [Admin, Write, AdvertSettingsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdvertSettings"];

    public class UpdateAdvertSettingCommandHandler : IRequestHandler<UpdateAdvertSettingCommand, UpdatedAdvertSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertSettingRepository _advertSettingRepository;
        private readonly AdvertSettingBusinessRules _advertSettingBusinessRules;

        public UpdateAdvertSettingCommandHandler(IMapper mapper, IAdvertSettingRepository advertSettingRepository,
                                         AdvertSettingBusinessRules advertSettingBusinessRules)
        {
            _mapper = mapper;
            _advertSettingRepository = advertSettingRepository;
            _advertSettingBusinessRules = advertSettingBusinessRules;
        }

        public async Task<UpdatedAdvertSettingResponse> Handle(UpdateAdvertSettingCommand request, CancellationToken cancellationToken)
        {
            AdvertSetting? advertSetting = await _advertSettingRepository.GetAsync(predicate: ads => ads.Id == request.Id, cancellationToken: cancellationToken);
            await _advertSettingBusinessRules.AdvertSettingShouldExistWhenSelected(advertSetting);
            advertSetting = _mapper.Map(request, advertSetting);

            await _advertSettingRepository.UpdateAsync(advertSetting!);

            UpdatedAdvertSettingResponse response = _mapper.Map<UpdatedAdvertSettingResponse>(advertSetting);
            return response;
        }
    }
}