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
        //await _context.SaveChangesAsync();
        var users = _context.Users.ToList();
        var responseUser = users.Select(x => new User(){Id = x.Id, GarageId = x.GarageId, Name = x.Name, Surname = x.Surname,CreatedTime = x.CreatedTime});
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