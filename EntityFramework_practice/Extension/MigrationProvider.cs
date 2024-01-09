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
    }

    private static void InitAnnotationDb(IServiceScope scope)
    {
        var migrationFiles = Directory.GetFiles(Environment.CurrentDirectory + "\\Migration\\DataAnnotation");
        var annotationContext = scope.ServiceProvider.GetRequiredService<DbContextApp>();
        if (migrationFiles.Any())
        {
            for (int i = 0; i < migrationFiles.Length - 1; i += 2)
            {
                var migrationName = migrationFiles[i].Split("\\")[^1]
                    .Split(".")[0];
               annotationContext.GetInfrastructure().GetService<IMigrator>()!.MigrateAsync(migrationName);
            }
        }
    }
}