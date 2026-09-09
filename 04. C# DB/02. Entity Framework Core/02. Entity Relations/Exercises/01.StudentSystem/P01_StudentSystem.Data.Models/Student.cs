namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(100)]
    [Unicode(true)]
    [Required]
    public string Name { get; set; } = null!;

    [Column(TypeName="CHAR(10)")]
    public string? PhoneNumber { get; set; }
    
    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<Homework> Homework { get; set; }
        = new HashSet<Homework>();

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
        = new HashSet<StudentCourse>();
}
