using EntityFramework_practice.Repositories.ForFluentApi;

namespace EntityFramework_practice.Extension.Endpoints;

public static class ForFluentApi
{
    public static RouteGroupBuilder FluentApiEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/hello", () => "hello");
        group.MapPost("/SeedData", async (SeedData seedData) => await seedData.InitData());
        return group;
    }
}