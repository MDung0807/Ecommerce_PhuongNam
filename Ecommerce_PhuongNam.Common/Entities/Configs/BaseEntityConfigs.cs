using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_PhuongNam.Common.Entities.Configs;

public class BaseEntityConfigs<T> : IEntityTypeConfiguration<BaseEntity<T>>
{
    public void Configure(EntityTypeBuilder<BaseEntity<T>> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(x => x.DateCreate).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.DateUpdate).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.CreateBy).HasDefaultValue("system");
        builder.Property(x => x.UpdateBy).HasDefaultValue("system");
    }
}