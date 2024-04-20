using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OrderWasherConfiguration : IEntityTypeConfiguration<OrderWasher>
{
    public void Configure(EntityTypeBuilder<OrderWasher> builder)
    {
        builder.ToTable("OrderWashers").HasKey(ow => ow.Id);

        builder.Property(ow => ow.Id).HasColumnName("Id").IsRequired();
        builder.Property(ow => ow.TenantId).HasColumnName("TenantId");
        builder.Property(ow => ow.OrderId).HasColumnName("OrderId");
        builder.Property(ow => ow.WasherUserId).HasColumnName("WasherUserId");
        builder.Property(ow => ow.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ow => ow.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ow => ow.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ow => !ow.DeletedDate.HasValue);
    }
}