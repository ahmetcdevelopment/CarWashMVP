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

namespace Application.Features.AdvertSettings.Commands.Delete;

public class DeleteAdvertSettingCommand : IRequest<DeletedAdvertSettingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AdvertSettingsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdvertSettings"];

    public class DeleteAdvertSettingCommandHandler : IRequestHandler<DeleteAdvertSettingCommand, DeletedAdvertSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertSettingRepository _advertSettingRepository;
        private readonly AdvertSettingBusinessRules _advertSettingBusinessRules;

        public DeleteAdvertSettingCommandHandler(IMapper mapper, IAdvertSettingRepository advertSettingRepository,
                                         AdvertSettingBusinessRules advertSettingBusinessRules)
        {
            _mapper = mapper;
            _advertSettingRepository = advertSettingRepository;
            _advertSettingBusinessRules = advertSettingBusinessRules;
        }

        public async Task<DeletedAdvertSettingResponse> Handle(DeleteAdvertSettingCommand request, CancellationToken cancellationToken)
        {
            AdvertSetting? advertSetting = await _advertSettingRepository.GetAsync(predicate: ads => ads.Id == request.Id, cancellationToken: cancellationToken);
            await _advertSettingBusinessRules.AdvertSettingShouldExistWhenSelected(advertSetting);

            await _advertSettingRepository.DeleteAsync(advertSetting!);

            DeletedAdvertSettingResponse response = _mapper.Map<DeletedAdvertSettingResponse>(advertSetting);
            return response;
        }
    }
}