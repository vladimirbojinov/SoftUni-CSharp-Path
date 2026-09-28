namespace BookShelf.Controllers;

using BookShelf.Data;
using BookShelf.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AuthorController(LibraryDbContext dbContext) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Author> authors = dbContext.Authors
            .AsNoTracking()
            .ToArray();

        return View(authors);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        Author author = dbContext.Authors.Find(id);

        if (author is null) return NotFound();

        dbContext.Entry(author)
            .Collection(a => a.Books)
            .Load();

        return View(author);
    }
}
