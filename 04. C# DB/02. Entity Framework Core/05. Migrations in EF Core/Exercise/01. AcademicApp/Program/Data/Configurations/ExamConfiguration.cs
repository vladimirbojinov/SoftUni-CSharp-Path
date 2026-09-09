namespace Program.Data.Configuration;

using Program.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.HasKey(e => e.Id)
               .HasName("PK__Exams__3214EC079F07B7A6");

        builder.Property(e => e.Name)
               .HasMaxLength(100);
    }
}
