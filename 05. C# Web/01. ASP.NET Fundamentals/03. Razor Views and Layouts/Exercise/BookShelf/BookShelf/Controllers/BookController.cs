namespace BookShelf.Controllers;

using BookShelf.Data;
using BookShelf.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class BookController(LibraryDbContext dbContext) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Book> books = dbContext.Books
            .AsNoTracking()
            .Include(b => b.Author)
            .ToArray();

        return View(books);
    }

    [HttpGet]
    public IActionResult Create()
    {
        List<SelectListItem> authors = dbContext.Authors
            .AsNoTracking()
            .Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            })
            .ToList();

        ViewBag.Authors = authors;

        return View();
    }

    [HttpPost]
    public IActionResult Create(Book book)
    {
        dbContext.Add(book);
        dbContext.SaveChanges();

        return Redirect(nameof(Index));
    }
}
