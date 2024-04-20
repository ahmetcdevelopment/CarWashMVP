using Application.Features.OrderWashers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderWashers;

public class OrderWasherManager : IOrderWasherService
{
    private readonly IOrderWasherRepository _orderWasherRepository;
    private readonly OrderWasherBusinessRules _orderWasherBusinessRules;

    public OrderWasherManager(IOrderWasherRepository orderWasherRepository, OrderWasherBusinessRules orderWasherBusinessRules)
    {
        _orderWasherRepository = orderWasherRepository;
        _orderWasherBusinessRules = orderWasherBusinessRules;
    }

    public async Task<OrderWasher?> GetAsync(
        Expression<Func<OrderWasher, bool>> predicate,
        Func<IQueryable<OrderWasher>, IIncludableQueryable<OrderWasher, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OrderWasher? orderWasher = await _orderWasherRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return orderWasher;
    }

    public async Task<IPaginate<OrderWasher>?> GetListAsync(
        Expression<Func<OrderWasher, bool>>? predicate = null,
        Func<IQueryable<OrderWasher>, IOrderedQueryable<OrderWasher>>? orderBy = null,
        Func<IQueryable<OrderWasher>, IIncludableQueryable<OrderWasher, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OrderWasher> orderWasherList = await _orderWasherRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return orderWasherList;
    }

    public async Task<OrderWasher> AddAsync(OrderWasher orderWasher)
    {
        OrderWasher addedOrderWasher = await _orderWasherRepository.AddAsync(orderWasher);

        return addedOrderWasher;
    }

    public async Task<OrderWasher> UpdateAsync(OrderWasher orderWasher)
    {
        OrderWasher updatedOrderWasher = await _orderWasherRepository.UpdateAsync(orderWasher);

        return updatedOrderWasher;
    }

    public async Task<OrderWasher> DeleteAsync(OrderWasher orderWasher, bool permanent = false)
    {
        OrderWasher deletedOrderWasher = await _orderWasherRepository.DeleteAsync(orderWasher);

        return deletedOrderWasher;
    }
}
