using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BrandSerials;

public interface IBrandSerialService
{
    Task<BrandSerial?> GetAsync(
        Expression<Func<BrandSerial, bool>> predicate,
        Func<IQueryable<BrandSerial>, IIncludableQueryable<BrandSerial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<BrandSerial>?> GetListAsync(
        Expression<Func<BrandSerial, bool>>? predicate = null,
        Func<IQueryable<BrandSerial>, IOrderedQueryable<BrandSerial>>? orderBy = null,
        Func<IQueryable<BrandSerial>, IIncludableQueryable<BrandSerial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<BrandSerial> AddAsync(BrandSerial brandSerial);
    Task<BrandSerial> UpdateAsync(BrandSerial brandSerial);
    Task<BrandSerial> DeleteAsync(BrandSerial brandSerial, bool permanent = false);
}
