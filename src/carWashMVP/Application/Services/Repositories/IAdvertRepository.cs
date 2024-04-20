using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAdvertRepository : IAsyncRepository<Advert, Guid>, IRepository<Advert, Guid>
{
}