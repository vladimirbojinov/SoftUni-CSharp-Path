namespace P03_SalesDatabase.Data;

using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

public class SalesContext : DbContext
{
    public SalesContext() { }

    public SalesContext(DbContextOptions<SalesContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Sale> Sales { get; set; }

    public DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-L5SJ2D0\SQLEXPRESS;Database=Sales;Integrated Security=True;TrustServerCertificate=True;"
            );
    }
}
