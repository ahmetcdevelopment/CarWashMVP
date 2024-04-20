using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserTenantRepository : EfRepositoryBase<UserTenant, Guid, BaseDbContext>, IUserTenantRepository
{
    public UserTenantRepository(BaseDbContext context) : base(context)
    {
    }
}