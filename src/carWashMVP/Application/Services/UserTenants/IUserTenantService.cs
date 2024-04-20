using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserTenants;

public interface IUserTenantService
{
    Task<UserTenant?> GetAsync(
        Expression<Func<UserTenant, bool>> predicate,
        Func<IQueryable<UserTenant>, IIncludableQueryable<UserTenant, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserTenant>?> GetListAsync(
        Expression<Func<UserTenant, bool>>? predicate = null,
        Func<IQueryable<UserTenant>, IOrderedQueryable<UserTenant>>? orderBy = null,
        Func<IQueryable<UserTenant>, IIncludableQueryable<UserTenant, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserTenant> AddAsync(UserTenant userTenant);
    Task<UserTenant> UpdateAsync(UserTenant userTenant);
    Task<UserTenant> DeleteAsync(UserTenant userTenant, bool permanent = false);
}
