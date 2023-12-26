using System.ComponentModel.DataAnnotations;

namespace EntityFramework_practice.Entities.AnnotationCreations;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string CreatedTime { get; set; }
}