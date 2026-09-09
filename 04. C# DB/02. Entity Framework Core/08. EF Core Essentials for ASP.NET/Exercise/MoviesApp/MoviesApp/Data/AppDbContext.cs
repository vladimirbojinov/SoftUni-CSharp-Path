namespace MoviesApp.Data;

using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public virtual DbSet<Movie> Movies { get; set; } = null!;

    public virtual DbSet<Watchlist> Watchlists { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
