using EntityFramework_practice.Entities.FluentApi;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_practice.DataContext.ForFluentApi;

public class DbFluentApi : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TransactionHistory> TransactionHistories { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    
    public DbFluentApi(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionHistoryConfiguration());
    }
}