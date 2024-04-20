using Application.Features.Adverts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Adverts;

public class AdvertManager : IAdvertService
{
    private readonly IAdvertRepository _advertRepository;
    private readonly AdvertBusinessRules _advertBusinessRules;

    public AdvertManager(IAdvertRepository advertRepository, AdvertBusinessRules advertBusinessRules)
    {
        _advertRepository = advertRepository;
        _advertBusinessRules = advertBusinessRules;
    }

    public async Task<Advert?> GetAsync(
        Expression<Func<Advert, bool>> predicate,
        Func<IQueryable<Advert>, IIncludableQueryable<Advert, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Advert? advert = await _advertRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return advert;
    }

    public async Task<IPaginate<Advert>?> GetListAsync(
        Expression<Func<Advert, bool>>? predicate = null,
        Func<IQueryable<Advert>, IOrderedQueryable<Advert>>? orderBy = null,
        Func<IQueryable<Advert>, IIncludableQueryable<Advert, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Advert> advertList = await _advertRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return advertList;
    }

    public async Task<Advert> AddAsync(Advert advert)
    {
        Advert addedAdvert = await _advertRepository.AddAsync(advert);

        return addedAdvert;
    }

    public async Task<Advert> UpdateAsync(Advert advert)
    {
        Advert updatedAdvert = await _advertRepository.UpdateAsync(advert);

        return updatedAdvert;
    }

    public async Task<Advert> DeleteAsync(Advert advert, bool permanent = false)
    {
        Advert deletedAdvert = await _advertRepository.DeleteAsync(advert);

        return deletedAdvert;
    }
}
