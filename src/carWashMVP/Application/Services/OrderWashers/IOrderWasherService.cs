using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderWashers;

public interface IOrderWasherService
{
    Task<OrderWasher?> GetAsync(
        Expression<Func<OrderWasher, bool>> predicate,
        Func<IQueryable<OrderWasher>, IIncludableQueryable<OrderWasher, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<OrderWasher>?> GetListAsync(
        Expression<Func<OrderWasher, bool>>? predicate = null,
        Func<IQueryable<OrderWasher>, IOrderedQueryable<OrderWasher>>? orderBy = null,
        Func<IQueryable<OrderWasher>, IIncludableQueryable<OrderWasher, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OrderWasher> AddAsync(OrderWasher orderWasher);
    Task<OrderWasher> UpdateAsync(OrderWasher orderWasher);
    Task<OrderWasher> DeleteAsync(OrderWasher orderWasher, bool permanent = false);
}
