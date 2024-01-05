using EntityFramework_practice.Entities.FluentApi;
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
            .HasDefaultValue(0)
            .HasIdentityOptions(1, 1, 1, 100_000, true, 0)
            .HasColumnType("integer");

        builder.Property(p => p.Balance)
            .IsRequired()
            .HasColumnName(nameof(BankAccount.Balance))
            .HasColumnType("real");

        builder.HasOne<User>(u => u.User)
            .WithOne(b => b.BankAccount)
            .HasForeignKey<User>(x => x.BankAccountId);

        builder.HasMany<TransactionHistory>(x => x.TransactionHistories)
            .WithOne(x => x.ToUser.BankAccount)
            .HasForeignKey(x => x.ToUser.BankAccountId);
        
        builder.HasMany<TransactionHistory>(x => x.TransactionHistories)
            .WithOne(x => x.FromUser.BankAccount)
            .HasForeignKey(x => x.FromUser.BankAccountId);
    }
}