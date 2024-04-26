using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders").HasKey(o => o.Id);

        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.TenantId).HasColumnName("TenantId");
        builder.Property(o => o.UserCarId).HasColumnName("UserCarId");
        builder.Property(o => o.WasherCarId).HasColumnName("WasherCarId");
        builder.Property(o => o.Category).HasColumnName("Category");
        builder.Property(o => o.Status).HasColumnName("Status");
        builder.Property(o => o.Price).HasColumnName("Price");
        builder.Property(o => o.Date).HasColumnName("Date");
        builder.Property(o => o.Enlem).HasColumnName("Enlem");
        builder.Property(o => o.Boylam).HasColumnName("Boylam");
        builder.Property(o => o.BeforePictures).HasColumnName("BeforePictures");
        builder.Property(o => o.AfterPictures).HasColumnName("AfterPictures");
        builder.Property(o => o.Note).HasColumnName("Note");
        builder.Property(o => o.QrCode).HasColumnName("QrCode");
        builder.Property(o => o.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(o => o.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(o => o.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Tenant);//Her sipari� bir tenant'a aittir.
        builder.HasOne(x => x.UserCar);//Her sipari�te kullan�c�n�n bir arac� vard�r.
        builder.HasOne(x => x.WasherCar);//Arac� y�kamaya giden y�kamac�n�n arac�.
        builder.HasMany(x => x.OrderDetails);//Her sipari�in detaylar� vard�r
                                             //Sipari�in detaylar� pasta-cila gibidir.
        builder.HasMany(x => x.WasherUsers);//Arac� y�kayan ekipteki userlar.


        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}