namespace GarageApp.Controllers;

using GarageApp.Data;
using GarageApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class GarageController(GarageDbContext dbContext) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Garage> garages = dbContext.Garages
            .AsNoTracking()
            .Include(g => g.Cars)
            .OrderBy(g => g.Name)
            .ToList();

        return View(garages);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        if (id <= 0) return BadRequest("Something went wrong try again!");

        Garage? garage = dbContext.Garages
            .Find(id);

        if (garage is null) return NotFound();

        dbContext.Entry(garage)
            .Collection(g => g.Cars)
            .Load();

        return View(garage);
    }
}
