using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.TenantId).HasColumnName("TenantId");
        builder.Property(c => c.BrandSerialId).HasColumnName("BrandSerialId");
        builder.Property(c => c.BrandYear).HasColumnName("BrandYear");
        builder.Property(c => c.PlateCode).HasColumnName("PlateCode");
        builder.Property(c => c.ColorCode).HasColumnName("ColorCode");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Tenant);//Her Aracýn bir tenant'ý vardýr.
        builder.HasOne(x => x.BrandSerial);//Her aracýn bir marka modeli vardýr.

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}