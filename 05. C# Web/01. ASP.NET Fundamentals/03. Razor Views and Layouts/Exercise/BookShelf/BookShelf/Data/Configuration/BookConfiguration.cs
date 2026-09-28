namespace BookShelf.Data.Configuration;

using BookShelf.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book
            {
                Id = 1,
                Title = "The Hobbit",
                Year = 1937,
                AuthorId = 1
            },
            new Book
            {
                Id = 2,
                Title = "1984",
                Year = 1949,
                AuthorId = 2
            },
            new Book
            {
                Id = 3,
                Title = "Pride and Prejudice",
                Year = 1813,
                AuthorId = 3
            }
        );
    }
}
