using EntityFramework_practice.DataContext.ByProperty;
using EntityFramework_practice.DataContext.ForDataAnotation;
using EntityFramework_practice.Repositories.ForDataAnnotation;

namespace EntityFramework_practice.Extension;

public static class ServiceProviderExtension
{
    public static IServiceCollection AddDataContexts(this IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddAnnotationDataContext(config);
        serviceCollection.AddPropertyDataContext(config);
        serviceCollection.AddScoped<DbContextApp>();
        serviceCollection.AddScoped<SeedData>();
        
        return serviceCollection;
    }
    private static IServiceCollection AddAnnotationDataContext(this IServiceCollection serviceCollection, IConfiguration config)
    {
        Console.WriteLine(config.GetConnectionString("DataAnnotation"));
        serviceCollection.AddNpgsql<DbContextApp>(config.GetConnectionString("DataAnnotation"));
        return serviceCollection;
    }
    
    private static IServiceCollection AddPropertyDataContext(this IServiceCollection serviceCollection, IConfiguration config)
    {
        Console.WriteLine(config.GetConnectionString("DataProperty"));
        serviceCollection.AddNpgsql<DbContextProperty>(config.GetConnectionString("DataProperty"));
        return serviceCollection;
    }
}