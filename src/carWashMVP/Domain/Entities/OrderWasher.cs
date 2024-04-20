using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class OrderWasher : Entity<Guid>
{
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }//Hangi siparişin detayı
    public Guid WasherUserId { get; set; }//Yıkamaya giden kullanıcının Id'si

    #region VIRTUAL REFERENCES
    public virtual Tenant? Tenant { get; set; }
    public virtual Order? Order { get; set; }
    public virtual User? WasherUser { get; set; }

    #endregion
}
