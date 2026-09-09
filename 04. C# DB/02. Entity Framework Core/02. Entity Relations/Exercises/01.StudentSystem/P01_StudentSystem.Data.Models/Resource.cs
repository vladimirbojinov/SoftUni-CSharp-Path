namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [StringLength(50)]
    [Unicode(true)]
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [Unicode(false)]
    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public virtual Course Course { get; set; } = null!;
}
