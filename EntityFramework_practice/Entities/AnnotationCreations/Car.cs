using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework_practice.Entities.AnnotationCreations;

public class Car : BaseEntity
{
    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string Brand { get; set; }
    
    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string Model { get; set; }
    
    [Required]
    [MaxLength(10)]
    [MinLength(3)]
    public string CarNumber { get; set; }

    [ForeignKey(nameof(Garage.Id))]
    public Garage Garage { get; set; }
    
    [ForeignKey(nameof(User.Cars))]
    public User User { get; set; }
}