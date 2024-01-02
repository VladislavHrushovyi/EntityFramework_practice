namespace EntityFramework_practice.Entities.PropertyClass;

public class Vehicle : BaseEntity
{
    public string Name { get; set; }
    
    public int LicenseId { get; set; }
    public License License { get; set; }

    public int DriverId { get; set; }
    public ICollection<Driver> Drivers { get; set; }
}