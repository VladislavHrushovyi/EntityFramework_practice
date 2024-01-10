using EntityFramework_practice.DataContext.ForDataAnotation;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework_practice.Extension;

public static class MigrationProvider
{
    public static void InitializationDatabases(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        InitAnnotationDb(scope);
        InitPropertyDb(scope);
        InitFluentApiDb(scope);
    }

    private static void InitAnnotationDb(IServiceScope scope)
    {
        var annotationContext = scope.ServiceProvider.GetRequiredService<DbContextApp>();
        if (!annotationContext.Database.EnsureCreated())
        {
            var migrationNames = GetMigrationNames("\\Migration\\DataAnnotation");
            foreach (var migrationName in migrationNames)
            {
                annotationContext.GetInfrastructure().GetService<IMigrator>()!.MigrateAsync(migrationName);
            }   
        }
    }
    
    private static void InitPropertyDb(IServiceScope scope)
    {
        var annotationContext = scope.ServiceProvider.GetRequiredService<DbContextApp>();
        var migrationNames = GetMigrationNames("\\Migration\\DataProperty");
        foreach (var migrationName in migrationNames)
        {
            annotationContext.GetInfrastructure().GetService<IMigrator>()!.MigrateAsync(migrationName);
        }
    }
    
    private static void InitFluentApiDb(IServiceScope scope)
    {
        var annotationContext = scope.ServiceProvider.GetRequiredService<DbContextApp>();
        var migrationNames = GetMigrationNames("\\Migration\\FluentApi");
        foreach (var migrationName in migrationNames)
        {
            annotationContext.GetInfrastructure().GetService<IMigrator>()!.MigrateAsync(migrationName);
        }
    }

    private static IEnumerable<string> GetMigrationNames(string directoryPath)
    {
        var migrationFiles = Directory.GetFiles(Environment.CurrentDirectory + directoryPath);
        for (int i = 0; i < migrationFiles.Length - 1; i += 2)
        {
            var migrationName = migrationFiles[i].Split("\\")[^1]
                .Split(".")[0];

            yield return migrationName;
        }
    }
}