using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF.Configs;

public class DistrictConfigs : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        #region -- Properties --


        #endregion -- Properties --

        #region -- Relationship --

        builder.HasOne(x => x.AdministrativeUnit)
            .WithMany(x => x.Districts)
            .HasForeignKey("AdministrativeUnitId");

        builder.HasOne(x => x.Province)
            .WithMany(x => x.Districts)
            .HasForeignKey("ProvinceId");

        #endregion -- Relationship --
    }
}