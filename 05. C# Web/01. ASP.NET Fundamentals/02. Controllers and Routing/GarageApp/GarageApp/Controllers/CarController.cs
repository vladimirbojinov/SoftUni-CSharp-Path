namespace GarageApp.Controllers;

using GarageApp.Data;
using GarageApp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CarController(GarageDbContext dbContext) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        IEnumerable<Car> cars = dbContext.Cars
            .AsNoTracking()
            .Include(c => c.Garage)
            .OrderBy(c => c.Make)
            .ToList();

        return View(cars);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        if (id <= 0) return BadRequest("Something went wrong try again!");

        Car? car = dbContext.Cars
            .Find(id);

        if (car is null) return NotFound();

        dbContext.Entry(car)
            .Reference(c => c.Garage)
            .Load();

        return View(car);
    }

    [HttpGet]
    public IActionResult Search(string make)
    {
        make.Trim();

        if (make is null || string.IsNullOrWhiteSpace(make)) return NotFound("");

        IEnumerable<Car> cars = dbContext.Cars
            .AsNoTracking()
            .Where(c => c.Make.Contains(make))
            .OrderBy(c => c.Make)
            .ToList();

        return View("Index", cars);
    }
}
