using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Tenant : Entity<Guid>
{
    public string Name { get; set; }//Tenant'ın adı.
    public string Photo { get; set; }
    public string Biography { get; set; }
    public Guid Slug { get; set; }//Kiracının URL'de kullanılabilecek benzersiz bir kısa adı olabilir. Bu, özelleştirilmiş alt alan adları oluşturmak için kullanılabilir.
    public string TaxNumber { get; set; }//Geçici atıldı null bırakılabilir.
    public string Address { get; set; }//Tenant'ın adresi.
                                       //ödeme için bir şey eklenmesi gerekebilir
                                       //mesajlaşma için key vb bir şeyler gerekebilir
                                       //mesajlaşmadan sonra ortalama yanıt süresi eklenebilir
                                       //kaç adet sipariş aldı kaçını iptal etti vb istatistikler eklenebilir


    #region VIRTUAL REFERENCES
    public virtual ICollection<Advert> Adverts { get; set; } = default!;
    public virtual ICollection<AdvertItem> AdvertItems { get; set; } = default!;
    public virtual ICollection<Car> Cars { get; set; }= default!;
    public virtual ICollection<Comment> Comments { get; set; } = default!;
    public virtual ICollection<Order> Orders { get; set; } = default!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = default!;
    public virtual ICollection<OrderWasher> OrderWashers { get; set; } = default!;
    public virtual ICollection<User> Users { get; set; } = default!;
    #endregion
}
