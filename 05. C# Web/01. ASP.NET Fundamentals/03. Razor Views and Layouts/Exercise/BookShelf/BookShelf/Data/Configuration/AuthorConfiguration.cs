namespace BookShelf.Data.Configuration;

using BookShelf.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData(
            new Author
            {
                Id = 1,
                Name = "J.R.R. Tolkien",
                Country = "United Kingdom"
            },
            new Author
            {
                Id = 2,
                Name = "George Orwell",
                Country = "United Kingdom"
            },
            new Author
            {
                Id = 3,
                Name = "Jane Austen",
                Country = "United Kingdom"
            }
        );
    }
}
