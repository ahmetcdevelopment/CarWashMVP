using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class UserTenant : Entity<Guid>
{
    public Guid TenantId { get; set; }
    public Guid UserId { get; set; }
    #region VIRTUAL REFERENCES
    public virtual Tenant? Tenant { get; set; }
    public virtual User? User { get; set; }
    #endregion
}
