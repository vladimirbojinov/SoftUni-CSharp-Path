namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext() { }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
        :base(options) { }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Homework> Homeworks { get; set; }

    public DbSet<Resource> Resources { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<StudentCourse> StudentsCourses { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=StudentSystem;Trusted_Connection=True;Password=vb55softuni;Encrypt=False");
    }
}
