using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class AdvertItem : Entity<Guid>
{
    public Guid TenantId { get; set; }
    public Guid AdvertId { get; set; }//İlan Id'si
    public AdvertItemCategory CategoryId { get; set; }//Yıkama kategorisine göre itemler Dış yıkama, iç yıkama, iç dış yıkama vs. - Enum
    public string Name { get; set; }//Adı
    public decimal AdditionalPrice { get; set; }// Ek ücreti

    #region VIRTUAL REFERENCES
    public virtual Tenant? Tenant { get; set; }//İlan malzemesinin Müşteri Grubu
    public virtual Advert? Advert { get; set; }//Advert
    #endregion
}
