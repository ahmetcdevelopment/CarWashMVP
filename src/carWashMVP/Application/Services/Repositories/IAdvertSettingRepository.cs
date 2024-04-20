using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAdvertSettingRepository : IAsyncRepository<AdvertSetting, Guid>, IRepository<AdvertSetting, Guid>
{
}