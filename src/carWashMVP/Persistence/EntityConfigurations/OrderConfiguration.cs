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

        builder.HasOne(x => x.Tenant);//Her sipariþ bir tenant'a aittir.
        builder.HasOne(x => x.UserCar);//Her sipariþte kullanýcýnýn bir aracý vardýr.
        builder.HasOne(x => x.WasherCar);//Aracý yýkamaya giden yýkamacýnýn aracý.
        builder.HasMany(x => x.OrderDetails);//Her sipariþin detaylarý vardýr
                                             //Sipariþin detaylarý pasta-cila gibidir.
        builder.HasMany(x => x.WasherUsers);//Aracý yýkayan ekipteki userlar.


        builder.HasQueryFilter(o => !o.DeletedDate.HasValue);
    }
}