using System.ComponentModel.DataAnnotations;

namespace EntityFramework_practice.Entities.PropertyClass;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CreatedDate { get; set; }
}