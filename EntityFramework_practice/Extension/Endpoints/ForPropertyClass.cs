using EntityFramework_practice.Repositories.ForProperty;

namespace EntityFramework_practice.Extension.Endpoints;

public static class ForPropertyClass
{
    public static RouteGroupBuilder PropertyClassEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/hello", () => "hello");
        group.MapPost("/SeedData", async (SeedData seedData) => await seedData.InitData());
        return group;
    }
}