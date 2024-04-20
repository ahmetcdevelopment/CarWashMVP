using Application.Features.BrandSerials.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BrandSerials;

public class BrandSerialManager : IBrandSerialService
{
    private readonly IBrandSerialRepository _brandSerialRepository;
    private readonly BrandSerialBusinessRules _brandSerialBusinessRules;

    public BrandSerialManager(IBrandSerialRepository brandSerialRepository, BrandSerialBusinessRules brandSerialBusinessRules)
    {
        _brandSerialRepository = brandSerialRepository;
        _brandSerialBusinessRules = brandSerialBusinessRules;
    }

    public async Task<BrandSerial?> GetAsync(
        Expression<Func<BrandSerial, bool>> predicate,
        Func<IQueryable<BrandSerial>, IIncludableQueryable<BrandSerial, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BrandSerial? brandSerial = await _brandSerialRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return brandSerial;
    }

    public async Task<IPaginate<BrandSerial>?> GetListAsync(
        Expression<Func<BrandSerial, bool>>? predicate = null,
        Func<IQueryable<BrandSerial>, IOrderedQueryable<BrandSerial>>? orderBy = null,
        Func<IQueryable<BrandSerial>, IIncludableQueryable<BrandSerial, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BrandSerial> brandSerialList = await _brandSerialRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return brandSerialList;
    }

    public async Task<BrandSerial> AddAsync(BrandSerial brandSerial)
    {
        BrandSerial addedBrandSerial = await _brandSerialRepository.AddAsync(brandSerial);

        return addedBrandSerial;
    }

    public async Task<BrandSerial> UpdateAsync(BrandSerial brandSerial)
    {
        BrandSerial updatedBrandSerial = await _brandSerialRepository.UpdateAsync(brandSerial);

        return updatedBrandSerial;
    }

    public async Task<BrandSerial> DeleteAsync(BrandSerial brandSerial, bool permanent = false)
    {
        BrandSerial deletedBrandSerial = await _brandSerialRepository.DeleteAsync(brandSerial);

        return deletedBrandSerial;
    }
}
