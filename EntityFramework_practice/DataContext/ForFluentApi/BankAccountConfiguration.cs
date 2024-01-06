﻿using EntityFramework_practice.Entities.FluentApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework_practice.DataContext.ForFluentApi;

public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
{
    public void Configure(EntityTypeBuilder<BankAccount> builder)
    {
        builder.ToTable(nameof(BankAccount));

        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName(nameof(BankAccount.Id))
            .HasIdentityOptions(1, 1, 1, 100_000, true, 10)
            .UseIdentityColumn()
            .HasConversion<int>();

        builder.Property(p => p.Balance)
            .IsRequired()
            .HasColumnName(nameof(BankAccount.Balance))
            .HasConversion<decimal>();

        builder.HasOne<User>(u => u.User)
            .WithOne(b => b.BankAccount)
            .HasForeignKey<User>(x => x.BankAccountId);
        
    }
}