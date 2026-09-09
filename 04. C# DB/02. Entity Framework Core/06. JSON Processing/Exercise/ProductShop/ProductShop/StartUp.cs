namespace ProductShop;

using Data;
using DTOs.Import;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using ViJsonTools;

public class StartUp
{
    public static void Main()
    {
        string jsonFile = "categories-products.json";
        string inputJson = File.ReadAllText(JsonUtilities.GetJsonPath(jsonFile));

        using ProductShopContext context = new();
        context.Database.EnsureCreated();

        string output = GetUsersWithProducts(context);
        Console.WriteLine(output);
    }

    //01. Import Data
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        ImportUserDto[] importedUsers = JsonUtilities.Deserialize<ImportUserDto>(inputJson);

        List<User> users = new();
        foreach (ImportUserDto dboUser in importedUsers)
        {
            User user = new()
            {
                FirstName = dboUser.FirstName,
                LastName = dboUser.LastName,
                Age = dboUser.Age
            };

            users.Add(user);
        }

        context.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }

    //02. Import Products
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        ImportProductDto[] importedProducts = JsonUtilities.Deserialize<ImportProductDto>(inputJson);

        List<Product> products = new();
        foreach (ImportProductDto dboProduct in importedProducts)
        {
            Product product = new()
            {
                Name = dboProduct.Name,
                Price = dboProduct.Price,
                BuyerId = dboProduct.BuyerId,
                SellerId = dboProduct.SellerId,
            };

            products.Add(product);
        }

        context.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    //03. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        ImportCategoryDto[] importedCategories = JsonUtilities.Deserialize<ImportCategoryDto>(inputJson);

        List<Category> categories = new();
        foreach (ImportCategoryDto dboCategory in importedCategories)
        {
            if (dboCategory.Name is null) continue;

            Category category = new()
            {
                Name = dboCategory.Name
            };

            categories.Add(category);
        }

        context.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    //04. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        ImportCategoryProductDto[] importedCategoryProduct = JsonUtilities.Deserialize<ImportCategoryProductDto>(inputJson);

        List<CategoryProduct> categoryProducts = new();
        foreach (ImportCategoryProductDto dboCategoryProduct in importedCategoryProduct)
        {
            CategoryProduct categoryProduct = new()
            {
                CategoryId = dboCategoryProduct.CategoryId,
                ProductId = dboCategoryProduct.ProductId
            };

            categoryProducts.Add(categoryProduct);
        }

        context.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count}";
    }

    //05. Export Products in Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        var users = context.Products
            .AsNoTracking()
            .Where(p => p.Price >= 500 && p.Price <= 1_000)
            .Select(p => new
            {
                p.Name,
                p.Price,
                Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
            })
            .OrderBy(p => p.Price)
            .ToArray();

        return JsonUtilities.Serialize(users);
    }

    //06. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        var soldProducts = context.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId.HasValue)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToArray()
            })
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ToArray();

        return JsonUtilities.Serialize(soldProducts);
    }

    //07. Export Categories by Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .AsNoTracking()
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count,
                AveragePrice = c.CategoriesProducts
                                    .Average(cp => cp.Product.Price)
                                    .ToString("F2"),
                TotalRevenue = c.CategoriesProducts
                                    .Sum(cp => cp.Product.Price)
                                    .ToString("F2")
            })
            .OrderByDescending(c => c.ProductsCount)
            .ToArray();

        return JsonUtilities.Serialize(categories);
    }

    //08. Export Users and Products
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.ProductsSold.Count(p => p.BuyerId.HasValue),
                    Products = u.ProductsSold
                        .Where(p => p.BuyerId.HasValue)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                        .ToArray()
                }
            })
            .OrderByDescending(u => u.SoldProducts.Count)
            .ToArray();

        var usersAndProducts = new
        {
            UsersCount = users.Length,
            users
        };

        JsonSerializerOptions setting = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        return JsonUtilities.Serialize(usersAndProducts, setting);
    }
}