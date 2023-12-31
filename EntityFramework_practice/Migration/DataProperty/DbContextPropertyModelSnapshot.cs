﻿// <auto-generated />
using EntityFramework_practice.DataContext.ByProperty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework_practice.Migration.DataProperty
{
    [DbContext(typeof(DbContextProperty))]
    partial class DbContextPropertyModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DriverVehicle", b =>
                {
                    b.Property<int>("DriversId")
                        .HasColumnType("integer");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("integer");

                    b.HasKey("DriversId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("DriverVehicle");
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.PropertyClass.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("LicenseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LicenseId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.PropertyClass.License", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.PropertyClass.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DriverId")
                        .HasColumnType("integer");

                    b.Property<int>("LicenseId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LicenseId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("DriverVehicle", b =>
                {
                    b.HasOne("EntityFramework_practice.Entities.PropertyClass.Driver", null)
                        .WithMany()
                        .HasForeignKey("DriversId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework_practice.Entities.PropertyClass.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.PropertyClass.Driver", b =>
                {
                    b.HasOne("EntityFramework_practice.Entities.PropertyClass.License", "License")
                        .WithMany("Drivers")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("License");
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.PropertyClass.Vehicle", b =>
                {
                    b.HasOne("EntityFramework_practice.Entities.PropertyClass.License", "License")
                        .WithMany()
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("License");
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.PropertyClass.License", b =>
                {
                    b.Navigation("Drivers");
                });
#pragma warning restore 612, 618
        }
    }
}
