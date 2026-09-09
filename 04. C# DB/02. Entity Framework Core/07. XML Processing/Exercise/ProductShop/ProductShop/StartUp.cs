namespace ProductShop;

using Data;
using DTOs.Import;
using Microsoft.EntityFrameworkCore;
using Models;
using ProductShop.DTOs.Export;
using ViXmlTools;

public class StartUp
{
    public static void Main()
    {
        string xmlFile = "categories-products.xml";
        string path = XmlUtilities.GetXmlPath(xmlFile);
        string inputXml = File.ReadAllText(path);

        ProductShopContext context = new();
        context.Database.EnsureCreated();

        string output = GetUsersWithProducts(context);
        Console.WriteLine(output);
    }

    //01. Import Users
    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        ImportUsersDto[] importedUsers = XmlUtilities.Deserelize<ImportUsersDto>(inputXml, "Users");

        List<User> users = new();
        foreach (ImportUsersDto dtoUser in importedUsers)
        {
            User user = new()
            {
                FirstName = dtoUser.FirstName,
                LastName = dtoUser.LastName,
                Age = dtoUser.Age,
            };

            users.Add(user);
        }

        context.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}"; ;
    }

    //02. Import Products
    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        ImportProductsDto[] importedProducts = XmlUtilities.Deserelize<ImportProductsDto>(inputXml, "Products");

        List<Product> products = new();
        foreach (ImportProductsDto dtoProducts in importedProducts)
        {
            Product product = new()
            {
                Name = dtoProducts.Name,
                Price = dtoProducts.Price,
                SellerId = dtoProducts.SellerId,
                BuyerId = dtoProducts.BuyerId
            };

            products.Add(product);
        }

        context.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    //03. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputXml)
    {
        ImportCategoriesDto[] importedCategories = XmlUtilities.Deserelize<ImportCategoriesDto>(inputXml, "Categories");

        List<Category> categories = new();
        foreach (ImportCategoriesDto dtoCategories in importedCategories)
        {
            if (dtoCategories.Name is null) continue;

            Category category = new()
            {
                Name = dtoCategories.Name
            };

            categories.Add(category);
        }

        context.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    //04. Import Categories
    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
    {
        ImportCategoriesProductsDto[] importedCategoryProduct =
            XmlUtilities.Deserelize<ImportCategoriesProductsDto>(inputXml, "CategoryProducts");

        List<CategoryProduct> categoryProducts = new();
        foreach (ImportCategoriesProductsDto dtoCategoriesProducts in importedCategoryProduct)
        {
            if (!context.Products.Any(p => p.Id == dtoCategoriesProducts.ProductId)) continue;
            if (!context.Categories.Any(c => c.Id == dtoCategoriesProducts.CategoryId)) continue;

            CategoryProduct categoryProduct = new()
            {
                CategoryId = dtoCategoriesProducts.CategoryId,
                ProductId = dtoCategoriesProducts.ProductId
            };

            categoryProducts.Add(categoryProduct);
        }

        context.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count}";
    }

    //05. Export Products In Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        var products = context.Products
            .AsNoTracking()
            .Take(10)
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .Select(p => new ExportProductInRangeDto
            {
                Name = p.Name,
                Price = p.Price,
                Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
            })
            .OrderBy(p => p.Price)
            .ToArray();

        return XmlUtilities.Serialize(products, "Products");
    }

    //06. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        var soldProducts = context.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .Select(u => new ExportUserSoldProductsDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId.HasValue)
                    .Select(p => new ExportProductDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
            })
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ToArray();

        return XmlUtilities.Serialize(soldProducts, "Users");
    }

    //07. Export Categories by Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .AsNoTracking()
            .Select(c => new ExportCategoryDto
            {
                Name = c.Name,
                Count = c.CategoryProducts.Count,
                AveragePrice = c.CategoryProducts
                                    .Average(cp => cp.Product.Price),
                TotalRevenue = c.CategoryProducts
                                    .Sum(cp => cp.Product.Price)
            })
            .OrderByDescending(c => c.Count)
            .ToArray();

        return XmlUtilities.Serialize(categories, "Categories");
    }

    //08. Export Users and Products
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .Select(u => new ExportUserWithProductsDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                SoldProducts = new ExportSoldProductsContainerDto
                {
                    Count = u.ProductsSold.Count(ps => ps.BuyerId != null),
                    Products = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new ExportProductDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(ps => ps.Price)
                        .ToArray()
                }
            })
            .OrderByDescending(u => u.SoldProducts.Count)
            .Take(10)
            .ToArray();

        ExportUserAndProductRootDto userAndProduct = new()
        {
            Count = context.Users.Count(u => u.ProductsSold.Any(ps => ps.BuyerId != null)),
            Users = users
        };

        return XmlUtilities.Serialize(userAndProduct, "Users");
    }
}