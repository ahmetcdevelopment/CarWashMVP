using Application.Features.AdvertSettings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdvertSettings;

public class AdvertSettingManager : IAdvertSettingService
{
    private readonly IAdvertSettingRepository _advertSettingRepository;
    private readonly AdvertSettingBusinessRules _advertSettingBusinessRules;

    public AdvertSettingManager(IAdvertSettingRepository advertSettingRepository, AdvertSettingBusinessRules advertSettingBusinessRules)
    {
        _advertSettingRepository = advertSettingRepository;
        _advertSettingBusinessRules = advertSettingBusinessRules;
    }

    public async Task<AdvertSetting?> GetAsync(
        Expression<Func<AdvertSetting, bool>> predicate,
        Func<IQueryable<AdvertSetting>, IIncludableQueryable<AdvertSetting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AdvertSetting? advertSetting = await _advertSettingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return advertSetting;
    }

    public async Task<IPaginate<AdvertSetting>?> GetListAsync(
        Expression<Func<AdvertSetting, bool>>? predicate = null,
        Func<IQueryable<AdvertSetting>, IOrderedQueryable<AdvertSetting>>? orderBy = null,
        Func<IQueryable<AdvertSetting>, IIncludableQueryable<AdvertSetting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AdvertSetting> advertSettingList = await _advertSettingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return advertSettingList;
    }

    public async Task<AdvertSetting> AddAsync(AdvertSetting advertSetting)
    {
        AdvertSetting addedAdvertSetting = await _advertSettingRepository.AddAsync(advertSetting);

        return addedAdvertSetting;
    }

    public async Task<AdvertSetting> UpdateAsync(AdvertSetting advertSetting)
    {
        AdvertSetting updatedAdvertSetting = await _advertSettingRepository.UpdateAsync(advertSetting);

        return updatedAdvertSetting;
    }

    public async Task<AdvertSetting> DeleteAsync(AdvertSetting advertSetting, bool permanent = false)
    {
        AdvertSetting deletedAdvertSetting = await _advertSettingRepository.DeleteAsync(advertSetting);

        return deletedAdvertSetting;
    }
}
