using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_practice.Entities.AnnotationCreations;

public class Garage : BaseEntity
{
    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string CityName { get; set; }
    
    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string StreetName { get; set; }
    
    [Required]
    [MaxLength(1)]
    [MinLength(5)]
    public string HouseNumber { get; set; }
    
    [ForeignKey(nameof(Car.Id))]
    public virtual ICollection<Car> Cars { get; set; }

    public User User { get; set; }
}