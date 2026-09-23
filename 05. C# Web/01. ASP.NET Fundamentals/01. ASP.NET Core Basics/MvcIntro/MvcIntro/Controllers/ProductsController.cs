namespace MvcIntro.Controllers;

using Microsoft.AspNetCore.Mvc;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Info = "An important announcement for 50% discount!";

        return View();
    }

    public IActionResult Details(int id)
    {
        if (id <= 0)
            return NotFound("Invalid product Id!");

        return Ok(id);
    }
}
