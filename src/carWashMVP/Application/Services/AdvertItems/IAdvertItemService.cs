using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdvertItems;

public interface IAdvertItemService
{
    Task<AdvertItem?> GetAsync(
        Expression<Func<AdvertItem, bool>> predicate,
        Func<IQueryable<AdvertItem>, IIncludableQueryable<AdvertItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AdvertItem>?> GetListAsync(
        Expression<Func<AdvertItem, bool>>? predicate = null,
        Func<IQueryable<AdvertItem>, IOrderedQueryable<AdvertItem>>? orderBy = null,
        Func<IQueryable<AdvertItem>, IIncludableQueryable<AdvertItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AdvertItem> AddAsync(AdvertItem advertItem);
    Task<AdvertItem> UpdateAsync(AdvertItem advertItem);
    Task<AdvertItem> DeleteAsync(AdvertItem advertItem, bool permanent = false);
}
