namespace BookShop;

using BookShop.Data;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        using BookShopContext contextDb = new();
        //DbInitializer.ResetDatabase(db);
        string output = RemoveBooks(contextDb).ToString();

        Console.WriteLine(output);
    }

    //02. Age Restriction
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, ignoreCase: true);

        var books = context.Books
            .AsNoTracking()
            .Where(b => b.AgeRestriction == ageRestriction)
            .Select(b => new
            {
                b.Title
            })
            .OrderBy(b => b.Title)
            .ToArray();

        StringBuilder sb = new();
        foreach (var b in books)
            sb.AppendLine(b.Title);

        return sb.ToString().Trim();
    }

    //03. Golden Books
    public static string GetGoldenBooks(BookShopContext context)
    {
        EditionType editionType = EditionType.Gold;

        var books = context.Books
            .AsNoTracking()
            .OrderBy(b => b.BookId)
            .Where(b => b.EditionType == editionType &&
                        b.Copies < 5000)
            .Select(b => new
            {
                b.Title
            })
            .ToArray();

        StringBuilder sb = new();
        foreach (var b in books)
            sb.AppendLine(b.Title);

        return sb.ToString().Trim();
    }


    //04. Books by Price
    public static string GetBooksByPrice(BookShopContext context)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Price > 40)
            .Select(b => new
            {
                b.Title,
                b.Price
            })
            .OrderByDescending(b => b.Price)
            .ToArray();

        StringBuilder sb = new();
        foreach (var b in books)
            sb.AppendLine($"{b.Title} - ${b.Price:F2}");

        return sb.ToString().Trim();
    }

    //05. Not Released In
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var book = context.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate.Value.Year != year)
            .OrderBy(b => b.BookId)
            .Select(b => new
            {
                b.Title
            })
            .ToArray();

        StringBuilder sb = new();
        foreach (var b in book)
            sb.AppendLine(b.Title);

        return sb.ToString();
    }

    //06. Book Titles by Category
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        string[] categories = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(c => c.ToLower())
            .ToArray();

        var book = context.Books
            .AsNoTracking()
            .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
            .Select(b => new
            {
                b.Title
            })
            .OrderBy(b => b.Title)
            .ToArray();

        StringBuilder sb = new();
        foreach (var b in book)
            sb.AppendLine(b.Title);

        return sb.ToString().Trim();
    }

    //07. Released Before Date
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        DateTime filterDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        var book = context.Books
            .AsNoTracking()
            .Where(b => b.ReleaseDate < filterDate)
            .OrderByDescending(b => b.ReleaseDate)
            .Select(b => new
            {
                b.Title,
                b.EditionType,
                b.Price
            })
            .ToArray();

        StringBuilder sb = new();
        foreach (var b in book)
            sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");

        return sb.ToString().Trim();
    }

    //08. Author Search
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var authors = context.Authors
            .AsNoTracking()
            .Where(a => a.FirstName.EndsWith(input))
            .Select(a => new
            {
                a.FirstName,
                a.LastName
            })
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .ToArray();

        StringBuilder sb = new();
        foreach (var a in authors)
            sb.AppendLine($"{a.FirstName} {a.LastName}");

        return sb.ToString().Trim();
    }

    //09. Book Search
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var books = context.Books
            .AsNoTracking()
            .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            .Select(b => new
            {
                b.Title
            })
            .OrderBy(b => b.Title)
            .ToArray();

        StringBuilder sb = new();
        foreach (var b in books)
            sb.AppendLine(b.Title);

        return sb.ToString().Trim();
    }

    //10. Book Search by Author
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var books = context.Books
            .AsNoTracking()
            .OrderBy(b => b.BookId)
            .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
            .Select(b => new
            {
                b.Title,
                AuthorFirstName = b.Author.FirstName,
                AuthorLastName = b.Author.LastName
            })
            .ToArray();

        StringBuilder sb = new();
        foreach (var b in books)
            sb.AppendLine($"{b.Title} ({b.AuthorFirstName} {b.AuthorLastName})");

        return sb.ToString().Trim();
    }

    //11. Count Books
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        int count = context.Books
            .AsNoTracking()
            .Where(b => b.Title.Length > lengthCheck)
            .Count();

        return count;
    }

    //12. Total Book Copies
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var authors = context.Authors
            .AsNoTracking()
            .Select(a => new
            {
                a.FirstName,
                a.LastName,
                TotalBookCopies = a.Books.Sum(b => b.Copies)
            })
            .OrderByDescending(a => a.TotalBookCopies)
            .ToArray();

        StringBuilder sb = new();
        foreach (var a in authors)
            sb.AppendLine($"{a.FirstName} {a.LastName} - {a.TotalBookCopies}");

        return sb.ToString().Trim();
    }

    //13. Profit by Category
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var categories = context.Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                BookTotalPrice = c.CategoryBooks
                    .Sum(b => b.Book.Copies * b.Book.Price)
            })
            .OrderByDescending(b => b.BookTotalPrice)
            .ToArray();

        StringBuilder sb = new();
        foreach (var c in categories)
            sb.AppendLine($"{c.Name} ${c.BookTotalPrice:F2}");

        return sb.ToString().Trim();
    }

    //14. Most Recent Books
    public static string GetMostRecentBooks(BookShopContext context)
    {
        var categories = context.Categories
            .AsNoTracking()
            .Select(c => new
            {
                c.Name,
                Books = c.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3)
                    .Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate!.Value.Year
                    })
                    .ToArray()
            })
            .OrderBy(c => c.Name)
            .ToArray();

        StringBuilder sb = new();
        foreach (var c in categories)
        {
            sb.AppendLine($"--{c.Name}");
            foreach (var b in c.Books)
                sb.AppendLine($"{b.Title} ({b.Year})");
        }

        return sb.ToString().Trim();
    }

    //15. Increase Prices
    public static void IncreasePrices(BookShopContext context)
    {
        int updateCount = context.Books
            .Where(b => b.ReleaseDate.Value.Year < 2010)
            .ExecuteUpdate(b => b.SetProperty(b => b.Price, b => b.Price + 5));
    }

    //16. Remove Books
    public static int RemoveBooks(BookShopContext context)
    {
        int deleteCount = context.Books
            .Where(b => b.Copies < 4200)
            .ExecuteDelete();

        return deleteCount;
    }
}
