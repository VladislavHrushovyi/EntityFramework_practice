using System.Collections;
using System.Globalization;
using EntityFramework_practice.DataContext.ForDataAnotation;
using EntityFramework_practice.Entities.AnnotationCreations;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_practice.Repositories.ForDataAnnotation;

public class SeedData(DbContextApp context)
{
    private readonly DbContextApp _context = context;
    public async Task<IEnumerable<User>> FillDataBase()
    {
        await RemoveAllRecordsOfAllTables();
        await InitGarages();
        await InitUsers();
        InitCars();
        await context.Users.AddRangeAsync();
        await context.SaveChangesAsync();

        return context.Users.ToList();
    }

    private async Task RemoveAllRecordsOfAllTables()
    {
        context.Users.RemoveRange(context.Users);
        context.Garages.RemoveRange(context.Garages);
        context.Cars.RemoveRange(context.Cars);
        await _context.SaveChangesAsync();
    }

    private void InitCars()
    {
        
    }

    private async Task InitUsers()
    {
        var garages = await context.Garages.Include(garage => garage.Users).ToListAsync();
        foreach (var garage in garages)
        {
            var garageUsers = Enumerable.Range(0, 5).Select(i =>
            {
                var user = new User()
                {
                    Name = "Name" + i,
                    Surname = "Surname" + i,
                    CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    Garage = garage,
                    GarageId = garage.Id
                };
                garage.Users.Add(user);
                return user;
            }).ToList();
            await context.Users.AddRangeAsync(garageUsers);
        }
        await context.SaveChangesAsync();
    }

    private async Task InitGarages()
    {
        var garages = Enumerable.Range(0, 3).Select(i => new Garage()
        {
            Id = i + 1,
            CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            HouseNumber = $"{i}",
            CityName = "City" + i,
            StreetName = "Street" + i,
        });
        await context.Garages.AddRangeAsync(garages);
        await context.SaveChangesAsync();
    }
}