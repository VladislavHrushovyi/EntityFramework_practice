using System.Collections;
using System.Globalization;
using EntityFramework_practice.DataContext.ForDataAnotation;
using EntityFramework_practice.Entities.AnnotationCreations;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_practice.Repositories.ForDataAnnotation;

public class SeedData
{
    private readonly DbContextApp _context;

    public SeedData(DbContextApp context)
    {
        _context = context;
    }

    public IEnumerable<User> FillDataBase()
    {
        var task = RemoveAllRecordsOfAllTables();
        while (!task.IsCompleted)
        {
            
        }
        InitGarages();
        InitUsers();
        InitCars();
        var users = _context.Users.Include(x => x.Garage)
            .Include(user => user.Cars)
            .ToList();
        var responseUser = users
            .Select(x => new User()
            {
                Id = x.Id, 
                GarageId = x.GarageId, 
                Name = x.Name,
                Surname = x.Surname,
                CreatedTime = x.CreatedTime,
                Garage = new Garage()
                {
                    Id = x.Garage.Id,
                    CreatedTime = x.Garage.CreatedTime,
                    HouseNumber = x.Garage.HouseNumber,
                    CityName = x.Garage.CityName,
                    StreetName = x.Garage.StreetName
                },
                Cars = x.Cars.Select(c => new Car()
                {
                    Id = c.Id,
                    CreatedTime = c.CreatedTime,
                    Brand = c.Brand,
                    Model = c.Model,
                    CarNumber = c.CarNumber
                }).ToList()
            });
        return responseUser;
    }

    private async Task RemoveAllRecordsOfAllTables()
    {
        _context.Users.RemoveRange(_context.Users);
        _context.Garages.RemoveRange(_context.Garages);
        _context.Cars.RemoveRange(_context.Cars);
        await _context.SaveChangesAsync();
    }

    private void InitCars()
    {
        var users = _context.Users;
        int carIdx = 0;
        foreach (var user in users)
        {
            var userCars = Enumerable.Range(0, 3).Select(i => new Car()
            {
                Id = carIdx + 100,
                CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                GarageId = user.GarageId,
                Brand = "Brand" + (carIdx + 100),
                Model = "Model" + (carIdx + 100),
                CarNumber = "CN" + (carIdx++ + 100),
                UserId = user.Id,
                Garage = user.Garage,
                User = user
            });
            
            _context.Cars.AddRange(userCars);
        }

        _context.SaveChanges();
    }

    private void InitUsers()
    {
        int userIdx = 0;
        var garages = _context.Garages.Include(garage => garage.Users).ToList();
        foreach (var garage in garages)
        {
            var garageUsers = Enumerable.Range(0, 5).Select(i => new User()
            {
                Id = userIdx++ + 100,
                Name = "Name" + i,
                Surname = "Surname" + i,
                CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                GarageId = garage.Id,
                Garage = garage,
                Cars = new List<Car>(),
            });
            
            _context.Users.AddRange(garageUsers);
        }

        _context.SaveChanges();
    }

    private void InitGarages()
    {
        var garages = Enumerable.Range(0, 3).Select(i => new Garage()
        {
            Id = i + 1,
            CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            HouseNumber = $"{i}",
            CityName = "City" + i,
            StreetName = "Street" + i,
            Users = new List<User>(),
            Cars = new List<Car>()
        });
        _context.Garages.AddRange(garages);
        _context.SaveChanges();
    }
}