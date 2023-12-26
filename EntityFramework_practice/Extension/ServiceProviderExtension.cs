using EntityFramework_practice.DataContext.ForDataAnotation;
using EntityFramework_practice.Repositories.ForDataAnnotation;

namespace EntityFramework_practice.Extension;

public static class ServiceProviderExtension
{
    public static IServiceCollection AddDataContexts(this IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddAnnotationDataContext(config);
        serviceCollection.AddScoped<DbContextApp>();
        serviceCollection.AddTransient<SeedData>();
        
        return serviceCollection;
    }
    private static IServiceCollection AddAnnotationDataContext(this IServiceCollection serviceCollection, IConfiguration config)
    {
        Console.WriteLine(config.GetConnectionString("DataAnnotation"));
        serviceCollection.AddNpgsql<DbContextApp>(config.GetConnectionString("DataAnnotation"));
        return serviceCollection;
    }
}