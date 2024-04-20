using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdvertSettings;

public interface IAdvertSettingService
{
    Task<AdvertSetting?> GetAsync(
        Expression<Func<AdvertSetting, bool>> predicate,
        Func<IQueryable<AdvertSetting>, IIncludableQueryable<AdvertSetting, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AdvertSetting>?> GetListAsync(
        Expression<Func<AdvertSetting, bool>>? predicate = null,
        Func<IQueryable<AdvertSetting>, IOrderedQueryable<AdvertSetting>>? orderBy = null,
        Func<IQueryable<AdvertSetting>, IIncludableQueryable<AdvertSetting, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AdvertSetting> AddAsync(AdvertSetting advertSetting);
    Task<AdvertSetting> UpdateAsync(AdvertSetting advertSetting);
    Task<AdvertSetting> DeleteAsync(AdvertSetting advertSetting, bool permanent = false);
}
