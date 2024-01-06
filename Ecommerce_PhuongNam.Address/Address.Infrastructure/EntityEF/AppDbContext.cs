using Ecommerce_PhuongNam.Address.Address.Domain.Entities;
using Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF.Configs;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
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
    
    public DbSet<AdministrativeRegion> AdministrativeRegions { get; set; }
    public DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Ward> Wards { get; set; }
}