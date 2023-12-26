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
        await InitCars();
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

    private async Task InitCars()
    {
        var users = context.Users.AsNoTracking().ToList();
        int idx = 0;
        var cars = new List<Car>();
        foreach (var user in users)
        {
            var userCars = Enumerable.Range(0, 3).Select(i => new Car()
            {
                CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                GarageId = user.GarageId,
                Brand = "Brand" + idx,
                Model = "Model" + idx,
                CarNumber = "CarNumber" + idx,
                UserId = user.Id
            });
            cars.AddRange(userCars);
        }
        
        await _context.Cars.AddRangeAsync(cars);
        //await _context.SaveChangesAsync();
    }

    private async Task InitUsers()
    {
        var garages = context.Garages.AsNoTracking().ToList();
        int idx = 0;
        var users = new List<User>();
        foreach (var garage in garages)
        {
            var garageUser = Enumerable.Range(0, 5).Select(i => new User()
            {
                Name = "Name" + idx,
                Surname = "Surname" + idx++,
                GarageId = garage.Id,
                CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                UGarage = garage,
                Cars = new List<Car>(),
            }).ToArray();
            users.AddRange(garageUser);
        }
        await _context.Users.AddRangeAsync(users);
        //await _context.SaveChangesAsync();
    }

    private async Task InitGarages()
    {
        var garages = Enumerable.Range(0, 3).Select(i => new Garage()
        {
            CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            HouseNumber = $"{i}",
            CityName = "City" + i,
            StreetName = "Street" + i
        }).ToArray();

        await _context.Garages.AddRangeAsync(garages);
        //await _context.SaveChangesAsync();
    }
}