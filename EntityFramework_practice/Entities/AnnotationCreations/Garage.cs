namespace EntityFramework_practice.Entities.AnnotationCreations;

public class Garage : BaseEntity
{
    public string CityName { get; set; }
    public string StreetName { get; set; }
    public string HouseNumber { get; set; }
    public ICollection<Car> Cars { get; set; }
}