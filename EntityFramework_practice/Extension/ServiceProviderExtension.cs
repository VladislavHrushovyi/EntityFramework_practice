using EntityFramework_practice.DataContext.ForDataAnotation;

namespace EntityFramework_practice.Extension;

public static class ServiceProviderExtension
{
    public static IServiceCollection AddDataContexts(this IServiceCollection serviceCollection, IConfiguration config)
    {
        serviceCollection.AddAnnotationDataContext(config);
        return serviceCollection;
    }
    private static IServiceCollection AddAnnotationDataContext(this IServiceCollection serviceCollection, IConfiguration config)
    {
        Console.WriteLine(config.GetConnectionString("DataAnnotation"));
        serviceCollection.AddNpgsql<DbContextApp>(config.GetConnectionString("DataAnnotation"));
        return serviceCollection;
    }
}