namespace EntityFramework_practice.Entities.PropertyClass;

public class Driver : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public int LicenseId { get; set; }
    public License License { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; }
}