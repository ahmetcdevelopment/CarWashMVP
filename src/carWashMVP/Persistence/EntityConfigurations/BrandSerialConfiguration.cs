using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BrandSerialConfiguration : IEntityTypeConfiguration<BrandSerial>
{
    public void Configure(EntityTypeBuilder<BrandSerial> builder)
    {
        builder.ToTable("BrandSerials").HasKey(bs => bs.Id);

        builder.Property(bs => bs.Id).HasColumnName("Id").IsRequired();
        builder.Property(bs => bs.ParentId).HasColumnName("ParentId");
        builder.Property(bs => bs.Depth).HasColumnName("Depth");
        builder.Property(bs => bs.CaseType).HasColumnName("CaseType");
        builder.Property(bs => bs.Name).HasColumnName("Name");
        builder.Property(bs => bs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bs => bs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bs => bs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(bs => bs.Cars); //Her markaya ait birden fazla araç vardýr.
        builder.HasOne(bs => bs.Parent);//Her markanýn bir üst markasý vardýr.
                                        //Eðer markanýn bir üst markasý yoksa parentId'si 0'dýr.

        builder.HasQueryFilter(bs => !bs.DeletedDate.HasValue);
    }
}