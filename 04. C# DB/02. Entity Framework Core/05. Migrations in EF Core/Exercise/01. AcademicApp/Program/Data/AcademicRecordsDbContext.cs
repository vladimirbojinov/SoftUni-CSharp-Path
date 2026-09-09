using Microsoft.EntityFrameworkCore;
using Program.Models;

namespace Program.Data;

public partial class AcademicRecordsDbContext : DbContext
{
    public AcademicRecordsDbContext() { }

    public AcademicRecordsDbContext(DbContextOptions<AcademicRecordsDbContext> options)
        : base(options) { }

    public virtual DbSet<Exam> Exams { get; set; } = null!;

    public virtual DbSet<Grade> Grades { get; set; } = null!;

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<Course> Courses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(DataBaseConfiguration.ConnectioString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AcademicRecordsDbContext).Assembly);

        modelBuilder.Entity<Student>()
                    .HasMany(s => s.Courses)
                    .WithMany(c => c.Students)
                    .UsingEntity<Dictionary<string, object>>(
                        "StudentCourses",
                        j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                        j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                        j =>
                        {
                            j.HasKey("StudentId", "CourseId");
                            j.ToTable("StudentCourses");
                        }
                    );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
