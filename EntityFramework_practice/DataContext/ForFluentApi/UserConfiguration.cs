using EntityFramework_practice.Entities.FluentApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework_practice.DataContext.ForFluentApi;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnName(nameof(User.Id))
            .HasIdentityOptions(1, 1, 1, 100_000, true, 10)
            .UseIdentityColumn()
            .HasConversion<int>();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName(nameof(User.Name))
            .HasMaxLength(50);

        builder.Property(p => p.Surname)
            .IsRequired()
            .HasColumnName(nameof(User.Surname))
            .HasMaxLength(50);

        builder.Property(x => x.BankAccountId)
            .IsRequired()
            .HasConversion<int>()
            .HasColumnName(nameof(User.BankAccountId));

        builder.HasOne<BankAccount>(b => b.BankAccount)
            .WithOne(x => x.User)
            .HasForeignKey<User>(x => x.BankAccountId);
    }
}