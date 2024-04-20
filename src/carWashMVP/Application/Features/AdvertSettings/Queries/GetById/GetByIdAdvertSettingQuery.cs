using Application.Features.AdvertSettings.Constants;
using Application.Features.AdvertSettings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AdvertSettings.Constants.AdvertSettingsOperationClaims;

namespace Application.Features.AdvertSettings.Queries.GetById;

public class GetByIdAdvertSettingQuery : IRequest<GetByIdAdvertSettingResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAdvertSettingQueryHandler : IRequestHandler<GetByIdAdvertSettingQuery, GetByIdAdvertSettingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertSettingRepository _advertSettingRepository;
        private readonly AdvertSettingBusinessRules _advertSettingBusinessRules;

        public GetByIdAdvertSettingQueryHandler(IMapper mapper, IAdvertSettingRepository advertSettingRepository, AdvertSettingBusinessRules advertSettingBusinessRules)
        {
            _mapper = mapper;
            _advertSettingRepository = advertSettingRepository;
            _advertSettingBusinessRules = advertSettingBusinessRules;
        }

        public async Task<GetByIdAdvertSettingResponse> Handle(GetByIdAdvertSettingQuery request, CancellationToken cancellationToken)
        {
            AdvertSetting? advertSetting = await _advertSettingRepository.GetAsync(predicate: ads => ads.Id == request.Id, cancellationToken: cancellationToken);
            await _advertSettingBusinessRules.AdvertSettingShouldExistWhenSelected(advertSetting);

            GetByIdAdvertSettingResponse response = _mapper.Map<GetByIdAdvertSettingResponse>(advertSetting);
            return response;
        }
    }
}