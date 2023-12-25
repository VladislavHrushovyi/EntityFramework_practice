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
    
    [ForeignKey(nameof(Garage.Id))]
    public Garage UGarage { get; set; }

    public int GarageId { get; set; }
    
    public virtual ICollection<Car> Cars { get; set; }
}