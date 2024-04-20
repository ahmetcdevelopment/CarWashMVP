using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class UserTenantConfiguration : IEntityTypeConfiguration<UserTenant>
{
    public void Configure(EntityTypeBuilder<UserTenant> builder)
    {
        builder.ToTable("UserTenants").HasKey(ut => ut.Id);

        builder.Property(ut => ut.Id).HasColumnName("Id").IsRequired();
        builder.Property(ut => ut.TenantId).HasColumnName("TenantId");
        builder.Property(ut => ut.UserId).HasColumnName("UserId");
        builder.Property(ut => ut.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ut => ut.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ut => ut.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ut => !ut.DeletedDate.HasValue);
    }
}