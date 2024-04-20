using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Adverts.Constants;
using Application.Features.AdvertItems.Constants;
using Application.Features.AdvertSettings.Constants;
using Application.Features.BrandSerials.Constants;
using Application.Features.Cars.Constants;
using Application.Features.Comments.Constants;
using Application.Features.Orders.Constants;
using Application.Features.OrderDetails.Constants;
using Application.Features.OrderWashers.Constants;
using Application.Features.Tenants.Constants;
using Application.Features.UserTenants.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Adverts
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Read },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Write },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Create },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Update },
                new() { Id = ++lastId, Name = AdvertsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region AdvertItems
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AdvertItemsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AdvertItemsOperationClaims.Read },
                new() { Id = ++lastId, Name = AdvertItemsOperationClaims.Write },
                new() { Id = ++lastId, Name = AdvertItemsOperationClaims.Create },
                new() { Id = ++lastId, Name = AdvertItemsOperationClaims.Update },
                new() { Id = ++lastId, Name = AdvertItemsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region AdvertSettings
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AdvertSettingsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AdvertSettingsOperationClaims.Read },
                new() { Id = ++lastId, Name = AdvertSettingsOperationClaims.Write },
                new() { Id = ++lastId, Name = AdvertSettingsOperationClaims.Create },
                new() { Id = ++lastId, Name = AdvertSettingsOperationClaims.Update },
                new() { Id = ++lastId, Name = AdvertSettingsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BrandSerials
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BrandSerialsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BrandSerialsOperationClaims.Read },
                new() { Id = ++lastId, Name = BrandSerialsOperationClaims.Write },
                new() { Id = ++lastId, Name = BrandSerialsOperationClaims.Create },
                new() { Id = ++lastId, Name = BrandSerialsOperationClaims.Update },
                new() { Id = ++lastId, Name = BrandSerialsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cars
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarsOperationClaims.Read },
                new() { Id = ++lastId, Name = CarsOperationClaims.Write },
                new() { Id = ++lastId, Name = CarsOperationClaims.Create },
                new() { Id = ++lastId, Name = CarsOperationClaims.Update },
                new() { Id = ++lastId, Name = CarsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Comments
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CommentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Read },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Write },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Create },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Update },
                new() { Id = ++lastId, Name = CommentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Orders
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OrdersOperationClaims.Admin },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Read },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Write },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Create },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Update },
                new() { Id = ++lastId, Name = OrdersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region OrderDetails
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Read },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Write },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Create },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Update },
                new() { Id = ++lastId, Name = OrderDetailsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region OrderWashers
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OrderWashersOperationClaims.Admin },
                new() { Id = ++lastId, Name = OrderWashersOperationClaims.Read },
                new() { Id = ++lastId, Name = OrderWashersOperationClaims.Write },
                new() { Id = ++lastId, Name = OrderWashersOperationClaims.Create },
                new() { Id = ++lastId, Name = OrderWashersOperationClaims.Update },
                new() { Id = ++lastId, Name = OrderWashersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Tenants
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TenantsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TenantsOperationClaims.Read },
                new() { Id = ++lastId, Name = TenantsOperationClaims.Write },
                new() { Id = ++lastId, Name = TenantsOperationClaims.Create },
                new() { Id = ++lastId, Name = TenantsOperationClaims.Update },
                new() { Id = ++lastId, Name = TenantsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region UserTenants
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserTenantsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserTenantsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserTenantsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserTenantsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserTenantsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserTenantsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
