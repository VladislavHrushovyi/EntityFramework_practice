﻿using EntityFramework_practice.DataContext.ByProperty;
using EntityFramework_practice.DataContext.ForDataAnotation;
using EntityFramework_practice.DataContext.ForFluentContext;
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
        using var annotationContext = scope.ServiceProvider.GetRequiredService<DbContextApp>();
        
        if (annotationContext.Database.EnsureCreated()) return;
        
        var migrationNames = GetMigrationNames("\\Migration\\DataAnnotation");
        foreach (var migrationName in migrationNames)
        {
            annotationContext.GetInfrastructure().GetService<IMigrator>()!.MigrateAsync(migrationName).GetAwaiter().GetResult();
        }
    }

    private static void InitPropertyDb(IServiceScope scope)
    {
        using var propertyContext = scope.ServiceProvider.GetRequiredService<DbContextProperty>();
        
        if (propertyContext.Database.EnsureCreated()) return;
        
        var migrationNames = GetMigrationNames("\\Migration\\DataProperty");
        foreach (var migrationName in migrationNames)
        {
            propertyContext.GetInfrastructure().GetService<IMigrator>()!.MigrateAsync(migrationName).GetAwaiter().GetResult();
        }
    }

    private static void InitFluentApiDb(IServiceScope scope)
    {
        using var fluentContext = scope.ServiceProvider.GetRequiredService<DbFluentContext>();

        if (fluentContext.Database.EnsureCreated()) return;
        
        var migrationNames = GetMigrationNames("\\Migration\\FluentApi");
        foreach (var migrationName in migrationNames)
        {
            fluentContext.GetInfrastructure().GetService<IMigrator>()!.MigrateAsync(migrationName).GetAwaiter().GetResult();
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