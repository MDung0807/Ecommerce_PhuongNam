
using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF.Configs;

public class ProvinceConfigs : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        #region -- Properties --

        #endregion -- Properties --

        #region -- Relationship --

        builder.HasOne(x => x.AdministrativeRegion)
            .WithMany(x => x.Provinces)
            .HasForeignKey("AdministrativeRegionId");

        builder.HasOne(x => x.AdministrativeUnit)
            .WithMany(x => x.Provinces)
            .HasForeignKey("AdministrativeUnitId");

        #endregion -- Relationship --
    }
}