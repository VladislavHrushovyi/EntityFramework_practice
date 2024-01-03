using System.Globalization;
using EntityFramework_practice.DataContext.ByProperty;
using EntityFramework_practice.Entities.PropertyClass;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_practice.Repositories.ForProperty;

public class SeedData
{
    private readonly DbContextProperty _context;

    public SeedData(DbContextProperty context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Driver>> InitData()
    {
        await RemoveData();
        await InitLicense();
        await InitDrivers();
        await InitVehicles();
        return _context.Drivers.Include(x => x.Vehicles).Select(d => new Driver()
        {
            Id = d.Id,
            LicenseId = d.LicenseId,
            CreatedDate = d.CreatedDate,
            Name = d.Name,
            Surname = d.Surname,
            License = new License()
            {
                Id = d.LicenseId,
                CreatedDate = d.License.CreatedDate,
                Type = d.License.Type
            },
            Vehicles = d.Vehicles.Select(v => new Vehicle()
            {
                Id = v.Id,
                LicenseId = v.Id,
                CreatedDate = v.CreatedDate,
                Name = v.Name,
                DriverId = v.DriverId,
            }).ToList()
        });
    }

    private async Task RemoveData()
    {
        _context.Licenses.RemoveRange(_context.Licenses);
        _context.Drivers.RemoveRange(_context.Drivers);
        _context.Vehicles.RemoveRange(_context.Vehicles);
        await _context.SaveChangesAsync();
    }

    private async Task InitLicense()
    {
        var licenses = Enumerable.Range(0, 5).Select(i => new License()
        {
            Id = i + 1,
            CreatedDate = DateTime.Now.ToString(CultureInfo.CurrentCulture),
            Type = "Type" + i
        });

        await _context.Licenses.AddRangeAsync(licenses);
        await _context.SaveChangesAsync();
    }

    private async Task InitDrivers()
    {
        var licenses = _context.Licenses;
        int driverIdx = 0;
        foreach (var license in licenses)
        {
            var drivers = Enumerable.Range(0, 5).Select(i => new Driver()
            {
                Id = driverIdx + 100,
                CreatedDate = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                Surname = "Surname" + driverIdx,
                Name = "Name" + driverIdx++,
                LicenseId = license.Id,
                License = license
            });

           await _context.Drivers.AddRangeAsync(drivers);
        }

        await _context.SaveChangesAsync();
    }

    private async Task InitVehicles()
    {
        var drivers = _context.Drivers.Include(driver => driver.License).ToList();
        int vehicleIdx = 0;

        foreach (var driver in drivers)
        {
            var vehicle = Enumerable.Range(0, Random.Shared.Next(5)).Select(i => new Vehicle()
            {
                Id = vehicleIdx + 100,
                CreatedDate = DateTime.Now.ToString(CultureInfo.CurrentCulture),
                DriverId = driver.Id,
                LicenseId = driver.LicenseId,
                License = driver.License,
                Name = "VehicleName" + vehicleIdx++,
            }).ToList();
            driver.Vehicles = vehicle;
            await _context.Vehicles.AddRangeAsync(vehicle);
        }

        await _context.SaveChangesAsync();
    }
}