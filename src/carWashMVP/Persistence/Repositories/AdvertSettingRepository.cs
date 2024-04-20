using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AdvertSettingRepository : EfRepositoryBase<AdvertSetting, Guid, BaseDbContext>, IAdvertSettingRepository
{
    public AdvertSettingRepository(BaseDbContext context) : base(context)
    {
    }
}