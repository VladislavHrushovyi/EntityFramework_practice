﻿using EntityFramework_practice.Entities.FluentContext;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_practice.DataContext.ForFluentContext;

public class DbFluentContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TransactionHistory> TransactionHistories { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }
    
    public DbFluentContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BankAccountConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionHistoryConfiguration());
    }
}