using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdvertConfiguration : IEntityTypeConfiguration<Advert>
{
    public void Configure(EntityTypeBuilder<Advert> builder)
    {
        builder.ToTable("Adverts").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.TenantId).HasColumnName("TenantId");
        builder.Property(a => a.WasherCarId).HasColumnName("WasherCarId");
        builder.Property(a => a.Enlem).HasColumnName("Enlem");
        builder.Property(a => a.Boylam).HasColumnName("Boylam");
        builder.Property(a => a.Range).HasColumnName("Range");
        builder.Property(a => a.Price).HasColumnName("Price");
        builder.Property(a => a.Title).HasColumnName("Title");
        builder.Property(a => a.PricePerDistance).HasColumnName("PricePerDistance");
        builder.Property(a => a.MinOrderAmount).HasColumnName("MinOrderAmount");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}