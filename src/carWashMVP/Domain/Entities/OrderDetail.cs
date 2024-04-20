using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class OrderDetail : Entity<Guid>
{
    public Guid TenantId { get; set; }
    public Guid AdvertItemId { get; set; }//Eklenen ilan iteminin Id'si
    public string Name { get; set; }//İşlem veya malzeme ismi
                                    //Veri tekrarı olmuş olsa da ileride yıkamacı AdvertItem'i güncellediğinde geçmiş işlemlerin
                                    //bundan etkilenmemesi için gerekli
    public decimal AdditionalPrice { get; set; }//Ek ücret
    public string Description { get; set; }

    #region VIRTUAL REFERENCES
    public virtual Tenant? Tenant { get; set; }//Sipariş detayının Müşteri Grubu
    public virtual AdvertItem? AdvertItem { get; set; }//Eklenen ilan iteminin

    #endregion
}
