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

namespace Application.Features.AdvertSettings.Commands.Create;

public class CreateAdvertSettingCommand : IRequest<CreatedAdvertSettingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid AdvertId { get; set; }
    public int DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public string[] Roles => [Admin, Write, AdvertSettingsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdvertSettings"];

    public class CreateAdvertSettingCommandHandler : IRequestHandler<CreateAdvertSettingCommand, CreatedAdvertSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertSettingRepository _advertSettingRepository;
        private readonly AdvertSettingBusinessRules _advertSettingBusinessRules;

        public CreateAdvertSettingCommandHandler(IMapper mapper, IAdvertSettingRepository advertSettingRepository,
                                         AdvertSettingBusinessRules advertSettingBusinessRules)
        {
            _mapper = mapper;
            _advertSettingRepository = advertSettingRepository;
            _advertSettingBusinessRules = advertSettingBusinessRules;
        }

        public async Task<CreatedAdvertSettingResponse> Handle(CreateAdvertSettingCommand request, CancellationToken cancellationToken)
        {
            AdvertSetting advertSetting = _mapper.Map<AdvertSetting>(request);

            await _advertSettingRepository.AddAsync(advertSetting);

            CreatedAdvertSettingResponse response = _mapper.Map<CreatedAdvertSettingResponse>(advertSetting);
            return response;
        }
    }
}