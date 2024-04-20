using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Comment : Entity<Guid>
{
    public Guid TenantId { get; set; }// yorumun hangi Tenant'a yapıldığı bilgisini tutar.
    public Guid AdvertId { get; set; }//Yorum hangi ilanın altında gözükecek.
    public Guid ParentId { get; set; }//Yorumlar ağaç yapısında olacak, yorumun altına yorum yapılabilecek.
                                     //Tenant sahibi yorum yaptığı zaman o yorumun tenant sahibine ait olduğu belli olacak.
    public int Rating { get; set; }// 5 yıldız, 1 yıldız
    public int UserId { get; set; }// yorumu yapan kullanıcı
    public int BrandSerialId { get; set; }// Hangi araba modelini yıkatmış
    public string Content { get; set; }//Yorum içeriği

    #region VIRTUAL REFERENCES
    public virtual Tenant? Tenant { get; set; }//Yorumun bir Müşteri Grubu vardır.
    public virtual Advert? Advert { get; set; }//Her yorum bir ilana aittir.
    public virtual Comment? Parent { get; set; } //Yorumun Parent'ı
    public virtual User? User { get; set; }//Yorumu yapan user.
    public virtual BrandSerial? BrandSerial { get; set; }// Hangi araba modelini yıkatmış
    #endregion
}
