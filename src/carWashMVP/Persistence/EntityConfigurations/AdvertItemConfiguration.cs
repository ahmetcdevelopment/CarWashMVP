using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdvertItemConfiguration : IEntityTypeConfiguration<AdvertItem>
{
    public void Configure(EntityTypeBuilder<AdvertItem> builder)
    {
        builder.ToTable("AdvertItems").HasKey(ai => ai.Id);

        builder.Property(ai => ai.Id).HasColumnName("Id").IsRequired();
        builder.Property(ai => ai.TenantId).HasColumnName("TenantId");
        builder.Property(ai => ai.AdvertId).HasColumnName("AdvertId");
        builder.Property(ai => ai.CategoryId).HasColumnName("CategoryId");
        builder.Property(ai => ai.Name).HasColumnName("Name");
        builder.Property(ai => ai.AdditionalPrice).HasColumnName("AdditionalPrice");
        builder.Property(ai => ai.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ai => ai.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ai => ai.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(ai => ai.Tenant);//Her ilan item'i bir tenant'a aittir.
        builder.HasOne(ai => ai.Advert);//Her ilan item'i bir ilana aittir.

        builder.HasQueryFilter(ai => !ai.DeletedDate.HasValue);
    }
}