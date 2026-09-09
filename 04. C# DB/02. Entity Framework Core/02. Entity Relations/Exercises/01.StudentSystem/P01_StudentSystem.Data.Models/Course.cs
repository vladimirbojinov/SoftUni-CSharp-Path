namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [StringLength(80)]
    [Unicode(true)]
    [Required]
    public string Name { get; set; } = null!;

    [Unicode(true)]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; } 

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Resource> Resources { get; set; }
        = new HashSet<Resource>();

    public virtual ICollection<Homework> Homeworks { get; set; }
        = new HashSet<Homework>();

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
        = new HashSet<StudentCourse>();
}
