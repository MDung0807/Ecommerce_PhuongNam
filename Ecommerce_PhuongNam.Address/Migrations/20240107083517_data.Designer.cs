﻿// <auto-generated />
using System;
using Ecommerce_PhuongNam.Address.Address.Infrastructure.EntityEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce_PhuongNam.Address.Migrations
{
    [DbContext(typeof(AddressDbContext))]
    [Migration("20240107083517_data")]
    partial class data
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.AdministrativeRegion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdministrativeRegions");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.AdministrativeUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdministrativeUnits");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdministrativeUnitId")
                        .HasColumnType("int");

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministrativeUnitId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdministrativeRegionId")
                        .HasColumnType("int");

                    b.Property<int?>("AdministrativeUnitId")
                        .HasColumnType("int");

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministrativeRegionId");

                    b.HasIndex("AdministrativeUnitId");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdministrativeUnitId")
                        .HasColumnType("int");

                    b.Property<string>("CodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullNameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministrativeUnitId");

                    b.HasIndex("DistrictId");

                    b.ToTable("Wards");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.District", b =>
                {
                    b.HasOne("Ecommerce_PhuongNam.Address.Address.Domain.Entities.AdministrativeUnit", "AdministrativeUnit")
                        .WithMany("Districts")
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Ecommerce_PhuongNam.Address.Address.Domain.Entities.Province", "Province")
                        .WithMany("Districts")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AdministrativeUnit");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.Province", b =>
                {
                    b.HasOne("Ecommerce_PhuongNam.Address.Address.Domain.Entities.AdministrativeRegion", "AdministrativeRegion")
                        .WithMany("Provinces")
                        .HasForeignKey("AdministrativeRegionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Ecommerce_PhuongNam.Address.Address.Domain.Entities.AdministrativeUnit", "AdministrativeUnit")
                        .WithMany("Provinces")
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AdministrativeRegion");

                    b.Navigation("AdministrativeUnit");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.Ward", b =>
                {
                    b.HasOne("Ecommerce_PhuongNam.Address.Address.Domain.Entities.AdministrativeUnit", "AdministrativeUnit")
                        .WithMany("Wards")
                        .HasForeignKey("AdministrativeUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ecommerce_PhuongNam.Address.Address.Domain.Entities.District", "District")
                        .WithMany("Wards")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AdministrativeUnit");

                    b.Navigation("District");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.AdministrativeRegion", b =>
                {
                    b.Navigation("Provinces");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.AdministrativeUnit", b =>
                {
                    b.Navigation("Districts");

                    b.Navigation("Provinces");

                    b.Navigation("Wards");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.District", b =>
                {
                    b.Navigation("Wards");
                });

            modelBuilder.Entity("Ecommerce_PhuongNam.Address.Address.Domain.Entities.Province", b =>
                {
                    b.Navigation("Districts");
                });
#pragma warning restore 612, 618
        }
    }
}
