using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF.Configs;
using Ecommerce_PhuongNam.Common.CurrentUserService;
using Ecommerce_PhuongNam.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF;

public class AddressDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;
    public AddressDbContext(DbContextOptions<AddressDbContext> options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AdministrativeRegionConfigs());
        modelBuilder.ApplyConfiguration(new AdministrativeUnitConfigs());
        modelBuilder.ApplyConfiguration(new ProvinceConfigs());
        modelBuilder.ApplyConfiguration(new DistrictConfigs());
        modelBuilder.ApplyConfiguration(new WardConfigs());

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (EntityEntry<BaseEntity<string>> entry in ChangeTracker.Entries<BaseEntity<string>>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreateBy = _currentUserService.IdUser;
                    entry.Entity.UpdateBy = _currentUserService.IdUser;
                    entry.Entity.DateCreate = DateTime.Now;
                    entry.Entity.DateUpdate = DateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Property(x => x.DateCreate).IsModified = false;
                    entry.Property(x => x.CreateBy).IsModified = false;
                    entry.Entity.DateUpdate = DateTime.Now;
                    entry.Entity.UpdateBy = _currentUserService.IdUser;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
                
    }

    public DbSet<AdministrativeRegion> AdministrativeRegions { get; set; }
    public DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Ward> Wards { get; set; }
}