using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_practice.Entities.AnnotationCreations;

public class User : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Surname { get; set; }

    public int GarageId { get; set; }

    public Garage Garage { get; set; }
    
    [InverseProperty(nameof(Car.User))]
    public virtual ICollection<Car> Cars { get; set; }
}