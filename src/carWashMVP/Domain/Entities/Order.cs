using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Order : Entity<Guid>
{
    // Kullanıcı kendi siparişlerini görürken UpdateUserId'den görecek.
    public Guid TenantId { get; set; }// Araç yıkamacının TenantId'si
    public Guid UserCarId { get; set; }// Yıkanacak arabanın Id'si
    public Guid WasherCarId { get; set; }// Arabayı yıkamak için gelecek araba
    public AdvertItemCategory Category { get; set; }// Siparişin Type'ı İç yıkama, dış yıkama, iç-dış yıkama
    public OrderStatus Status { get; set; }// Siparişin Durumu - yolda- tamamlandı - iptal edildi.
    public decimal Price { get; set; }// Sipariş ücreti
    public DateTime Date { get; set; }// Siparişin Tarihi ve Saati
    public double Enlem { get; set; }// Siparişin konumunun enlemi
    public double Boylam { get; set; }// Siparişin konumunun boylamı
    public string BeforePictures { get; set; }// photo;photo;
    public string AfterPictures { get; set; }// yıkandıktan sonraki resimleri -- bunu eklemeden status tamamlandıya çekilemez.
    public string Note { get; set; }//Siparişi verecek olan kullanıcının notu.
    public string QrCode { get; set; }

    #region VIRTUAL REFERENCES
    public virtual Tenant? Tenant { get; set; }//Siparişin müşteri grubu.
    public virtual Car? UserCar { get; set; }//Yıkanacak araba
    public virtual Car? WasherCar { get; set; }//Yıkayacak olan araba
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = default!;//Siparişin Detayları
    public virtual ICollection<User> WasherUsers { get; set; } = default!;//O siparişte arabayı yıkayan yıkamacılar.
    #endregion
}
