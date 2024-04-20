using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrderWasherRepository : IAsyncRepository<OrderWasher, Guid>, IRepository<OrderWasher, Guid>
{
}