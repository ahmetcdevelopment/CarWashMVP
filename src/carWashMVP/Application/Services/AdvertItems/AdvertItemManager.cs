using Application.Features.AdvertItems.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AdvertItems;

public class AdvertItemManager : IAdvertItemService
{
    private readonly IAdvertItemRepository _advertItemRepository;
    private readonly AdvertItemBusinessRules _advertItemBusinessRules;

    public AdvertItemManager(IAdvertItemRepository advertItemRepository, AdvertItemBusinessRules advertItemBusinessRules)
    {
        _advertItemRepository = advertItemRepository;
        _advertItemBusinessRules = advertItemBusinessRules;
    }

    public async Task<AdvertItem?> GetAsync(
        Expression<Func<AdvertItem, bool>> predicate,
        Func<IQueryable<AdvertItem>, IIncludableQueryable<AdvertItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AdvertItem? advertItem = await _advertItemRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return advertItem;
    }

    public async Task<IPaginate<AdvertItem>?> GetListAsync(
        Expression<Func<AdvertItem, bool>>? predicate = null,
        Func<IQueryable<AdvertItem>, IOrderedQueryable<AdvertItem>>? orderBy = null,
        Func<IQueryable<AdvertItem>, IIncludableQueryable<AdvertItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AdvertItem> advertItemList = await _advertItemRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return advertItemList;
    }

    public async Task<AdvertItem> AddAsync(AdvertItem advertItem)
    {
        AdvertItem addedAdvertItem = await _advertItemRepository.AddAsync(advertItem);

        return addedAdvertItem;
    }

    public async Task<AdvertItem> UpdateAsync(AdvertItem advertItem)
    {
        AdvertItem updatedAdvertItem = await _advertItemRepository.UpdateAsync(advertItem);

        return updatedAdvertItem;
    }

    public async Task<AdvertItem> DeleteAsync(AdvertItem advertItem, bool permanent = false)
    {
        AdvertItem deletedAdvertItem = await _advertItemRepository.DeleteAsync(advertItem);

        return deletedAdvertItem;
    }
}
