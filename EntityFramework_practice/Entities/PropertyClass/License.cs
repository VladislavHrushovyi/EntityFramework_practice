namespace EntityFramework_practice.Entities.PropertyClass;

public class License : BaseEntity
{
    public string Type { get; set; }

    public ICollection<Driver> Drivers { get; set; }
}