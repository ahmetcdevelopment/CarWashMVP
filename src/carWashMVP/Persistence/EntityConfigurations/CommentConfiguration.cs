using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.TenantId).HasColumnName("TenantId");
        builder.Property(c => c.AdvertId).HasColumnName("AdvertId");
        builder.Property(c => c.ParentId).HasColumnName("ParentId");
        builder.Property(c => c.Rating).HasColumnName("Rating");
        builder.Property(c => c.UserId).HasColumnName("UserId");
        builder.Property(c => c.BrandSerialId).HasColumnName("BrandSerialId");
        builder.Property(c => c.Content).HasColumnName("Content");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(x => x.Advert);//Her yorum bir ilana aittir.
        builder.HasOne(x => x.BrandSerial);//Yorumu yapan kullan�c�n�n arac�n�n marka modeli
        builder.HasOne(x => x.Parent);//Yorumlar da a�a� yap�s�nda tutuldu�u i�in her yorumun bir �st yorumu vard�r.
                                      //E�er yoksa parent� kendisidir.
        builder.HasOne(x => x.User);//Her yorum bir kullanc�ya aittir.
        builder.HasOne(x => x.Tenant);//Her yorum bir tenant'a aittir.

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}