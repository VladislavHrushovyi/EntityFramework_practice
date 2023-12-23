using System.ComponentModel.DataAnnotations;

namespace EntityFramework_practice.Entities.AnnotationCreations;

public class User : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Surname { get; set; }
    
    public ICollection<Garage> Garages { get; set; }
}