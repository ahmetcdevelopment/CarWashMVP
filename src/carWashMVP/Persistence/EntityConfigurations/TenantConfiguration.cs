using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("Tenants").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("Name");
        builder.Property(t => t.Photo).HasColumnName("Photo");
        builder.Property(t => t.Biography).HasColumnName("Biography");
        builder.Property(t => t.Slug).HasColumnName("Slug");
        builder.Property(t => t.TaxNumber).HasColumnName("TaxNumber");
        builder.Property(t => t.Address).HasColumnName("Address");
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(x => x.Adverts);
        builder.HasMany(x => x.Orders);
        builder.HasMany(x => x.OrderDetails);
        builder.HasMany(x => x.OrderWashers);
        builder.HasMany(x => x.Users);
        builder.HasMany(x => x.AdvertItems);
        builder.HasMany(x => x.Cars);
        builder.HasMany(x => x.Comments);

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}