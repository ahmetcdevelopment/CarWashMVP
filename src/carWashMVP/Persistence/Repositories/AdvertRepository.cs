using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdvertRepository : EfRepositoryBase<Advert, Guid, BaseDbContext>, IAdvertRepository
{
    public AdvertRepository(BaseDbContext context) : base(context)
    {
    }
}