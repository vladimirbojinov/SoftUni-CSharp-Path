namespace Program.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Program.Models;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id)
               .HasName("PK__Students__3214EC07F6F74CBC");

        builder.Property(s => s.FullName)
               .HasMaxLength(100);
    }
}
