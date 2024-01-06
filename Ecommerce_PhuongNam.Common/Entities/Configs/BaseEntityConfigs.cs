using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam.Common.Entities.Configs;

public class BaseEntityConfigs : IEntityTypeConfiguration<BaseEntity>
{
    public void Configure(EntityTypeBuilder<BaseEntity> builder)
    {
        builder.HasKey(x => x.Id);


        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasDefaultValue("NEWID()");
        builder.Property(x => x.DateCreate).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.DateUpdate).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.CreateBy).HasDefaultValue("system");
        builder.Property(x => x.UpdateBy).HasDefaultValue("system");
    }
}