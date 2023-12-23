namespace EntityFramework_practice.Entities.AnnotationCreations;

public class Car : BaseEntity
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string CarNumber { get; set; }
    public User User { get; set; }
}