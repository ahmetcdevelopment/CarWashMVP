using Application.Features.UserTenants.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserTenants;

public class UserTenantManager : IUserTenantService
{
    private readonly IUserTenantRepository _userTenantRepository;
    private readonly UserTenantBusinessRules _userTenantBusinessRules;

    public UserTenantManager(IUserTenantRepository userTenantRepository, UserTenantBusinessRules userTenantBusinessRules)
    {
        _userTenantRepository = userTenantRepository;
        _userTenantBusinessRules = userTenantBusinessRules;
    }

    public async Task<UserTenant?> GetAsync(
        Expression<Func<UserTenant, bool>> predicate,
        Func<IQueryable<UserTenant>, IIncludableQueryable<UserTenant, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserTenant? userTenant = await _userTenantRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userTenant;
    }

    public async Task<IPaginate<UserTenant>?> GetListAsync(
        Expression<Func<UserTenant, bool>>? predicate = null,
        Func<IQueryable<UserTenant>, IOrderedQueryable<UserTenant>>? orderBy = null,
        Func<IQueryable<UserTenant>, IIncludableQueryable<UserTenant, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserTenant> userTenantList = await _userTenantRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userTenantList;
    }

    public async Task<UserTenant> AddAsync(UserTenant userTenant)
    {
        UserTenant addedUserTenant = await _userTenantRepository.AddAsync(userTenant);

        return addedUserTenant;
    }

    public async Task<UserTenant> UpdateAsync(UserTenant userTenant)
    {
        UserTenant updatedUserTenant = await _userTenantRepository.UpdateAsync(userTenant);

        return updatedUserTenant;
    }

    public async Task<UserTenant> DeleteAsync(UserTenant userTenant, bool permanent = false)
    {
        UserTenant deletedUserTenant = await _userTenantRepository.DeleteAsync(userTenant);

        return deletedUserTenant;
    }
}
