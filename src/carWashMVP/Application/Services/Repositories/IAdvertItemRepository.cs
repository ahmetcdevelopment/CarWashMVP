using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAdvertItemRepository : IAsyncRepository<AdvertItem, Guid>, IRepository<AdvertItem, Guid>
{
}