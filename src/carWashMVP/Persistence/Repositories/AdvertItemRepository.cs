using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdvertItemRepository : EfRepositoryBase<AdvertItem, Guid, BaseDbContext>, IAdvertItemRepository
{
    public AdvertItemRepository(BaseDbContext context) : base(context)
    {
    }
}