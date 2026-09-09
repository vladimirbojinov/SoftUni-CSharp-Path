namespace MoviesApp.Controllers;

using Microsoft.AspNetCore.Mvc;

using ViewModels.Import;
using Services.Interfaces;

public class ImportController(IImportService importService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var model = new ImportIndexViewModel();

        if (TempData.ContainsKey("JsonImportedCount"))
        {
            model.JsonImportedCount = (int)TempData["JsonImportedCount"]!;
        }

        if (TempData.ContainsKey("XmlImportedCount"))
        {
            model.XmlImportedCount = (int)TempData["XmlImportedCount"]!;
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ImportJson()
    {
        int importedCount = await importService.ImportFromJsonAsync("moviesJSONFile.json");

        TempData["JsonImportedCount"] = importedCount;

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult ImportXml()
    {
        // TODO (students): implement real import logic in ImportService
        // int importedCount = _importService.ImportMoviesFromXml();
        int importedCount = 0; // placeholder for now

        TempData["XmlImportedCount"] = importedCount;

        return RedirectToAction(nameof(Index));
    }
}
