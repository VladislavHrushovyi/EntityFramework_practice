using EntityFramework_practice.Repositories.ForDataAnnotation;

namespace EntityFramework_practice.Extension.Endpoints;

public static class ForDataAnnotation
{
    public static RouteGroupBuilder DataAnnotationEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/hello", () => "hello");
        group.MapPost("/SeedData", (SeedData seedData) => seedData.FillDataBase());
        return group;
    }
}