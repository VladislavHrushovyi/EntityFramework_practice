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

    public async Task<IEnumerable<User>> FillDataBase()
    {
        await RemoveAllRecordsOfAllTables();
        await InitGarages();
        await InitUsers();
        InitCars();
        await _context.SaveChangesAsync();
        var users = _context.Users.ToList();
        var responseUser = users.Select(x => new User() { Id = x.Id, Name = x.Name});
        return responseUser;
    }

    private async Task RemoveAllRecordsOfAllTables()
    {
        _context.Users.RemoveRange(_context.Users);
        _context.Garages.RemoveRange(_context.Garages);
        _context.Cars.RemoveRange(_context.Cars);
        //await _context.SaveChangesAsync();
    }

    private void InitCars()
    {
        
    }

    private async Task InitUsers()
    {
        var garages = await _context.Garages.AsNoTracking().ToListAsync();
        foreach (var garage in garages)
        {
            var garageUsers = Enumerable.Range(0, 1).Select(i =>
            {
                var user = new User()
                {
                    Id = i + 100,
                    Name = "Name" + i,
                    Surname = "Surname" + i,
                    CreatedTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    Garage = garage,
                    GarageId = garage.Id
                };
                _context.Users.Add(user);
                return user;
            }).ToList();
            garage.Users = new List<User>(garageUsers);
            await _context.SaveChangesAsync();
            //users.AddRange(garageUsers);
        }

        //await _context.Users.AddRangeAsync(users);
        //await _context.SaveChangesAsync();
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
        await _context.Garages.AddRangeAsync(garages);
        await _context.SaveChangesAsync();
    }
}