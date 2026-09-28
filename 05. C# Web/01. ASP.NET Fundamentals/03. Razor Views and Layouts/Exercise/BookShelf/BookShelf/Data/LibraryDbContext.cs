namespace BookShelf.Data;

using BookShelf.Data.Configuration;
using BookShelf.Data.Models;
using Microsoft.EntityFrameworkCore;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options) { }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
    }
}
