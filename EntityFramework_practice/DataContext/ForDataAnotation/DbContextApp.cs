using EntityFramework_practice.Entities.AnnotationCreations;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_practice.DataContext.ForDataAnotation;

public class DbContextApp : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Garage> Garages { get; set; }
    public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
    {
    }
}