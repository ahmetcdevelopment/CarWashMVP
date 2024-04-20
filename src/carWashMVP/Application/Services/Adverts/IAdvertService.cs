using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Adverts;

public interface IAdvertService
{
    Task<Advert?> GetAsync(
        Expression<Func<Advert, bool>> predicate,
        Func<IQueryable<Advert>, IIncludableQueryable<Advert, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Advert>?> GetListAsync(
        Expression<Func<Advert, bool>>? predicate = null,
        Func<IQueryable<Advert>, IOrderedQueryable<Advert>>? orderBy = null,
        Func<IQueryable<Advert>, IIncludableQueryable<Advert, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Advert> AddAsync(Advert advert);
    Task<Advert> UpdateAsync(Advert advert);
    Task<Advert> DeleteAsync(Advert advert, bool permanent = false);
}
