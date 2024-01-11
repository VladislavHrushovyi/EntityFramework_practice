using EntityFramework_practice.Entities.FluentContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework_practice.DataContext.ForFluentContext;

public class TransactionHistoryConfiguration : IEntityTypeConfiguration<TransactionHistory>
{
    public void Configure(EntityTypeBuilder<TransactionHistory> builder)
    {
        builder.ToTable(nameof(TransactionHistory));

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName(nameof(TransactionHistory.Id))
            .HasIdentityOptions(1, 1, 1, 100_000, true, 10)
            .UseIdentityColumn()
            .HasConversion<int>();

        builder.Property(x => x.ActionType)
            .IsRequired()
            .HasColumnName(nameof(TransactionHistory.ActionType))
            .HasMaxLength(25);

        builder.Property(x => x.AmountMoney)
            .HasColumnName(nameof(TransactionHistory.AmountMoney))
            .IsRequired()
            .HasConversion<decimal>();

        builder.Property(x => x.FromAccountId)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.ToAccountId)
            .IsRequired()
            .HasConversion<int>();

        builder.HasOne<BankAccount>(x => x.FromAccount)
            .WithMany(x => x.TransactionHistories)
            .HasForeignKey(x => x.FromAccountId);
        
        // builder.HasOne<BankAccount>(x => x.ToAccount)
        //     .WithMany(x => x.TransactionHistories)
        //     .HasForeignKey(x => x.ToAccountId);
    }
}