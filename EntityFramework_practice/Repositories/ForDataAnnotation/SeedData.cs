using System.Globalization;
using EntityFramework_practice.DataContext.ForDataAnotation;
using EntityFramework_practice.Entities.AnnotationCreations;

namespace EntityFramework_practice.Repositories.ForDataAnnotation;

public class SeedData(DbContextApp context)
{
    public async Task<IEnumerable<User>> FillDataBase()
    {
        RemoveAllRecordsOfAllTables();
        InitGarages();
        InitUsers();
        InitCars();
        await context.SaveChangesAsync();

        return context.Users;
    }

    private void RemoveAllRecordsOfAllTables()
    {
        context.Users.RemoveRange(context.Users);
        context.Garages.RemoveRange(context.Garages);
        context.Cars.RemoveRange(context.Cars);
    }

    private void InitCars()
    {
        var users = context.Users.ToList();
        int idx = 0;
        foreach (var user in users)
        {
            var userCars = Enumerable.Range(0, 3).Select(i => new Car()
            {
                //Id = idx,
                CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                GarageId = user.GarageId,
                Brand = "Brand" + idx,
                Model = "Model" + idx,
                CarNumber = "CarNumber" + idx,
                UserId = user.Id
            });
            context.Cars.AddRange(userCars);
        }

        context.SaveChanges();
    }

    private void InitUsers()
    {
        var garages = context.Garages.ToList();
        int idx = 0;
        foreach (var garage in garages)
        {
            var garageUser = Enumerable.Range(0, 5).Select(i => new User()
            {
                Id = idx,
                Name = "Name" + idx,
                Surname = "Surname" + idx++,
                GarageId = garage.Id,
                CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                UGarage = garage
            }).ToArray();
            
            context.Users.AddRange(garageUser);
        }

        context.SaveChanges();
    }

    private void InitGarages()
    {
        var garages = Enumerable.Range(0, 3).Select(i => new Garage()
        {
            //Id = i,
            CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            HouseNumber = $"{i}",
            CityName = "City" + i,
            StreetName = "Street" + i
        }).ToArray();

        context.Garages.AddRange(garages);
        context.SaveChanges();
    }
}