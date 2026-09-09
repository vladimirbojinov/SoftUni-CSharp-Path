namespace MiniCinemaApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using MoviesApp.DTOs.Movie;
using MoviesApp.Services.Interfaces;
using MoviesApp.ViewModels.Movies;
using static MoviesApp.Common.AppConstants;

public class MoviesController(IMoviesService moviesService) : Controller
{
    public async Task<IActionResult> Index()
    {
        IEnumerable<MovieDto> movies = await moviesService.GetAllAsync();

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

    [HttpGet]
    public IActionResult Create()
    {
        AddMovieFormModel model = new()
        {
            ReleaseDate = DateOnly.FromDateTime(DateTime.Now)
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddMovieFormModel model)
    {
        if (!ModelState.IsValid) return View(model);

        MovieDto movie = new()
        {
            Title = model.Title,
            Genre = model.Genre,
            ReleaseDate = model.ReleaseDate,
            Director = model.Director,
            Duration = model.Duration,
            Description = model.Description,
            ImageUrl = string.IsNullOrWhiteSpace(model.ImageUrl) ?
                DefaultImageUrl :
                model.ImageUrl,
        };

        await moviesService.AddAsync(movie);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        MovieDto? movie = await moviesService.GetByIdAsync(id);

        if (movie is null)
            return NotFound();

        MovieDetailsViewModel movieDetails = new()
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            ReleaseDate = movie.ReleaseDate,
            Director = movie.Director,
            Duration = movie.Duration,
            Description = movie.Description,
            ImageUrl = movie.ImageUrl,
        };

        return View(movieDetails);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        MovieDto? movie = await moviesService.GetByIdAsync(id);

        if (movie == null)
            return NotFound();

        EditMovieFormModel formModel = new()
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate,
            Duration = movie.Duration,
            Description = movie.Description,
            ImageUrl = movie.ImageUrl,
        };

        return View(formModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditMovieFormModel model)
    {
        if (id != model.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(model);

        MovieDto? searchedMovie = await moviesService.GetByIdAsync(id);
        if (await moviesService.GetByIdAsync(id) is null)
            return NotFound();

        MovieDto movie = new()
        {
            Id = model.Id,
            Title = model.Title,
            Genre = model.Genre,
            Director = model.Director,
            ReleaseDate = model.ReleaseDate,
            Duration = model.Duration,
            Description = model.Description,
            ImageUrl = string.IsNullOrWhiteSpace(model.ImageUrl) ?
                DefaultImageUrl :
                model.ImageUrl,
        };

        await moviesService.UpdateAsync(movie);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        MovieDto? movie = await moviesService.GetByIdAsync(id);

        if (movie is null)
            return NotFound();

        AllMoviesIndexViewModel model = new()
        {
            Id = movie.Id,
            Title = movie.Title,
            Genre = movie.Genre,
            Director = movie.Director,
            ReleaseDate = movie.ReleaseDate.ToString("MM/dd/yyyy"),
            Duration = movie.Duration,
            Description = movie.Description,
            ImageUrl = movie.ImageUrl,
        };

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await moviesService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
}
