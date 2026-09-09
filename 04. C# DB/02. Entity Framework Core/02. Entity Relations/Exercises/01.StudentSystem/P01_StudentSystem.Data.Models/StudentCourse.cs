namespace P01_StudentSystem.Data.Models;

using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(StudentId), nameof(CourseId))]
public class StudentCourse
{
    public int StudentId { get; set; }
    public int CourseId { get; set; }

    public virtual Student Student { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
}
