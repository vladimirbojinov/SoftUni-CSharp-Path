namespace MoviesApp.Controllers;

using DTOs.Movie;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels.Movies;

public class WatchlistController(IMoviesService moviesService, IWatchlistService watchlistService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IEnumerable<MovieDto> movies = await watchlistService.GetAllAsync();

        List<AllMoviesIndexViewModel> viewModel = movies
            .Select(m => new AllMoviesIndexViewModel
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                Director = m.Director,
                ReleaseDate = m.ReleaseDate.ToString("MM/dd/yyyy"),
                Duration = m.Duration,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
            }).ToList();

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(int id)
    {
        bool exists = await moviesService.ExistsAsync(id);
        if (!exists)
            return NotFound();

        await watchlistService.AddAsync(id);

        return RedirectToAction("Index", "Movies");
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int id)
    {
        await watchlistService.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        MovieDto? movie = await moviesService.GetByIdAsync(id);

        if (movie == null)
            return NotFound();

        MovieDetailsViewModel model = new()
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            Director = movie.Director,
            Duration = movie.Duration,
        };

        model.Description = movie.Description;
        model.ImageUrl = movie.ImageUrl;

        return View(model);
    }
}
