using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BrandSerialRepository : EfRepositoryBase<BrandSerial, Guid, BaseDbContext>, IBrandSerialRepository
{
    public BrandSerialRepository(BaseDbContext context) : base(context)
    {
    }
}