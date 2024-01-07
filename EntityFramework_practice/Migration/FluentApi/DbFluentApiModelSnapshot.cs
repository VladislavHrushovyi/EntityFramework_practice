﻿// <auto-generated />
using System;
using EntityFramework_practice.DataContext.ForFluentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityFramework_practice.Migration.FluentApi
{
    [DbContext(typeof(DbFluentContext))]
    partial class DbFluentApiModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityFramework_practice.Entities.FluentApi.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1L, null, 1L, 100000L, true, 10L);

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric(38,17)")
                        .HasColumnName("Balance");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BankAccount", (string)null);
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.FluentApi.TransactionHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1L, null, 1L, 100000L, true, 10L);

                    b.Property<string>("ActionType")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)")
                        .HasColumnName("ActionType");

                    b.Property<decimal>("AmountMoney")
                        .HasColumnType("numeric(38,17)")
                        .HasColumnName("AmountMoney");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("integer");

                    b.Property<int>("ToAccountId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("ToAccountId");

                    b.ToTable("TransactionHistory", (string)null);
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.FluentApi.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));
                    NpgsqlPropertyBuilderExtensions.HasIdentityOptions(b.Property<int>("Id"), 1L, null, 1L, 100000L, true, 10L);

                    b.Property<int>("BankAccountId")
                        .HasColumnType("integer")
                        .HasColumnName("BankAccountId");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.FluentApi.TransactionHistory", b =>
                {
                    b.HasOne("EntityFramework_practice.Entities.FluentApi.BankAccount", "FromAccount")
                        .WithMany("TransactionHistories")
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework_practice.Entities.FluentApi.BankAccount", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.FluentApi.User", b =>
                {
                    b.HasOne("EntityFramework_practice.Entities.FluentApi.BankAccount", "BankAccount")
                        .WithOne("User")
                        .HasForeignKey("EntityFramework_practice.Entities.FluentApi.User", "BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("EntityFramework_practice.Entities.FluentApi.BankAccount", b =>
                {
                    b.Navigation("TransactionHistories");

                    b.Navigation("User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
