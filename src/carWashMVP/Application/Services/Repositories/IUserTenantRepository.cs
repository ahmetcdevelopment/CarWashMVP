using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserTenantRepository : IAsyncRepository<UserTenant, Guid>, IRepository<UserTenant, Guid>
{
}