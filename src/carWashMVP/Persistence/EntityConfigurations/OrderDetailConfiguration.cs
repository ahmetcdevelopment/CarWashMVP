using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails").HasKey(od => od.Id);

        builder.Property(od => od.Id).HasColumnName("Id").IsRequired();
        builder.Property(od => od.TenantId).HasColumnName("TenantId");
        builder.Property(od => od.AdvertItemId).HasColumnName("AdvertItemId");
        builder.Property(od => od.Name).HasColumnName("Name");
        builder.Property(od => od.AdditionalPrice).HasColumnName("AdditionalPrice");
        builder.Property(od => od.Description).HasColumnName("Description");
        builder.Property(od => od.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(od => od.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(od => od.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(od => !od.DeletedDate.HasValue);
    }
}