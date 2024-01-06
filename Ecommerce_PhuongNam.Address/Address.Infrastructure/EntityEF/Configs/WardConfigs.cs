using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF.Configs;

public class WardConfigs : IEntityTypeConfiguration<Ward>
{
    public void Configure(EntityTypeBuilder<Ward> builder)
    {
        #region -- Properties --

        #endregion -- Properties --

        #region -- Relationship --

        builder.HasOne(x => x.AdministrativeUnit)
            .WithMany(x => x.Wards)
            .HasForeignKey("AdministrativeUnitId")
            .IsRequired();

        builder.HasOne(x => x.District)
            .WithMany(x => x.Wards)
            .HasForeignKey("DistrictId")    
            .IsRequired();

        #endregion -- Relationship --
    }
}