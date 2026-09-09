namespace P03_SalesDatabase;

using P03_SalesDatabase.Data;
using P03_SalesDatabase.Data.Models;

public class Startup
{
    static void Main(string[] args)
    {
        using SalesContext context = new();
        SeedData(context);
    }

    // * Bonus Task - Make a seed method
    private static void SeedData(SalesContext context)
    {
        Random random = new();
        context.Database.EnsureCreated();

        if (!context.Customers.Any())
        {
            Customer[] customers =
            [
                new Customer {
                    Name = "Alice Vance",
                    Email = $"{new string("Alice Vance").Replace(" ", "").ToLower()}@gmail.com",
                    CreditCardNumber = $"{random.Next(1000, 9999)} {random.Next(1000, 9999)} {random.Next(1000, 9999)} {random.Next(1000, 9999)}"
                },
                new Customer {
                    Name = "Marcus Sterling",
                    Email = $"{new string("Marcus Sterling").Replace(" ", "").ToLower()}@gmail.com",
                    CreditCardNumber = $"{random.Next(1000, 9999)} {random.Next(1000, 9999)} {random.Next(1000, 9999)} {random.Next(1000, 9999)}"
                },
                new Customer {
                    Name = "Clara Montgomery",
                    Email = $"{new string("Clara Montgomery").Replace(" ", "").ToLower()}@gmail.com",
                    CreditCardNumber = $"{random.Next(1000, 9999)} {random.Next(1000, 9999)} {random.Next(1000, 9999)} {random.Next(1000, 9999)}"
                }
            ];

            context.AddRange(customers);
        }

        if (!context.Products.Any())
        {
            Product[] products =
            [
                new Product {
                    Name = "Desk Lamp",
                    Quantity = random.Next(1, 101),
                    Price = random.Next(1, 51) + 0.99m
                },
                new Product {
                    Name = "Running Shoes",
                    Quantity = random.Next(1, 101),
                    Price = random.Next(1, 51) + 0.99m
                },
                new Product {
                    Name = "Backpack",
                    Quantity = random.Next(1, 101),
                    Price = random.Next(1, 51) + 0.99m
                }
            ];

            context.AddRange(products);
        }

        if (!context.Customers.Any())
        {
            Store[] stores =
            [
                new Store {
                    Name = "Metro Nexus"
                },
                new Store {
                    Name = "Daily Depot"
                },
                new Store {
                    Name = "Horizon Goods"
                }
            ];

            context.AddRange(stores);
        }

        context.SaveChanges();

        if (!context.Sales.Any())
        {
            Sale[] sales =
            [
                new Sale {
                    Date = DateTime.Now
                        .AddDays(-random.Next(0, 90))
                        .AddHours(-random.Next(0, 25))
                        .AddMinutes(-random.Next(0, 60)),
                    ProductId = random.Next(1, 4),
                    CustomerId = random.Next(1, 4),
                    StoreId = random.Next(1, 4)
                },
                new Sale {
                    Date = DateTime.Now
                        .AddDays(-random.Next(0, 90))
                        .AddHours(-random.Next(0, 25))
                        .AddMinutes(-random.Next(0, 60)),
                    ProductId = random.Next(1, 4),
                    CustomerId = random.Next(1, 4),
                    StoreId = random.Next(1, 4)
                },
                new Sale {
                    Date = DateTime.Now
                        .AddDays(-random.Next(0, 90))
                        .AddHours(-random.Next(0, 25))
                        .AddMinutes(-random.Next(0, 60)),
                    ProductId = random.Next(1, 4),
                    CustomerId = random.Next(1, 4),
                    StoreId = random.Next(1, 4)
                },
                new Sale {
                    Date = DateTime.Now
                        .AddDays(-random.Next(0, 90))
                        .AddHours(-random.Next(0, 25))
                        .AddMinutes(-random.Next(0, 60)),
                    ProductId = random.Next(1, 4),
                    CustomerId = random.Next(1, 4),
                    StoreId = random.Next(1, 4)
                },
                new Sale {
                    Date = DateTime.Now
                        .AddDays(-random.Next(0, 90))
                        .AddHours(-random.Next(0, 25))
                        .AddMinutes(-random.Next(0, 60)),
                    ProductId = random.Next(1, 4),
                    CustomerId = random.Next(1, 4),
                    StoreId = random.Next(1, 4)
                }
            ];

            context.AddRange(sales);
        }

        context.SaveChanges();
    }
}
