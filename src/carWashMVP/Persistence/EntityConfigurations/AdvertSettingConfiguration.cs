using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AdvertSettingConfiguration : IEntityTypeConfiguration<AdvertSetting>
{
    public void Configure(EntityTypeBuilder<AdvertSetting> builder)
    {
        builder.ToTable("AdvertSettings").HasKey(ads=>ads.Id);

        builder.Property(ads=>ads.Id).HasColumnName("Id").IsRequired();
        builder.Property(ads=>ads.AdvertId).HasColumnName("AdvertId");
        builder.Property(ads=>ads.DayOfWeek).HasColumnName("DayOfWeek");
        builder.Property(ads=>ads.StartTime).HasColumnName("StartTime");
        builder.Property(ads=>ads.EndTime).HasColumnName("EndTime");
        builder.Property(ads=>ads.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ads=>ads.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ads=>ads.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Advert);//Her ilan ayarý bir ilana aittir.

        builder.HasQueryFilter(ads => !ads.DeletedDate.HasValue);
    }
}