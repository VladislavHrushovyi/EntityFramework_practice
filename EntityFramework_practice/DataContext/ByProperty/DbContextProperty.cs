using EntityFramework_practice.Entities.PropertyClass;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_practice.DataContext.ByProperty;

public class DbContextProperty : DbContext
{
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<License> Licenses { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public DbContextProperty(DbContextOptions<DbContextProperty> contextOptions) : base(contextOptions)
    {
        
    }
}