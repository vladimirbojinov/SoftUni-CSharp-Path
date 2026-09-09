namespace Program.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Program.Models;

internal class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasKey(g => g.Id)
               .HasName("PK__Grades__3214EC07E72297E7");

        builder.Property(g => g.Value)
               .HasColumnType("decimal(3, 2)");

        builder.HasOne(e => e.Exam)
               .WithMany(g => g.Grades)
               .HasForeignKey(g => g.ExamId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Grades_Exams");

        builder.HasOne(s => s.Student)
               .WithMany(g => g.Grades)
               .HasForeignKey(g => g.StudentId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Grades_Students");
    }
}
