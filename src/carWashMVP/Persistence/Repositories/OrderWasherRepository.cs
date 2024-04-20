using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderWasherRepository : EfRepositoryBase<OrderWasher, Guid, BaseDbContext>, IOrderWasherRepository
{
    public OrderWasherRepository(BaseDbContext context) : base(context)
    {
    }
}