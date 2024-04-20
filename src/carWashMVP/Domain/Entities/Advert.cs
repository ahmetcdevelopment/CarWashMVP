using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Advert : Entity<Guid>
{
    public Guid TenantId { get; set; }
    public Guid WasherCarId { get; set; }//Yıkayacak olan aracın Id'si
    public double Enlem { get; set; }//İlanın o anki konumunun enlemi
    public double Boylam { get; set; }//İlanın o anki konumunun boylamı
    public double Range { get; set; }// Siparişe gideceği range
    public decimal Price { get; set; }//Siparişin ücreti.
    public string Title { get; set; }// İlanın başlığı
    public double PricePerDistance { get; set; }//Kilometre başına yol ücreti
    public double MinOrderAmount { get; set; }//Minimum sipariş tutarı

    #region VIRTUAL REFERENCES
    public virtual Tenant? Tenant { get; set; }//İlanın Müşteri Grubu
    public virtual Car? Car { get; set; } // Yıkayacak olan araç
    public virtual ICollection<AdvertItem> AdvertItems { get; set; } = default!;//İlan malzemeleri
    public virtual ICollection<AdvertSetting> AdvertSettings { get; set; } = default!;//İlan Ayarları
    #endregion
}
