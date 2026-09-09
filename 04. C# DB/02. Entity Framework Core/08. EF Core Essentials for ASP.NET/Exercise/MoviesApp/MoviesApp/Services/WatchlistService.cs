namespace MoviesApp.Services;

using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.DTOs.Movie;
using MoviesApp.Models;
using MoviesApp.Services.Interfaces;

public class WatchlistService(AppDbContext context) : IWatchlistService
{
    public async Task AddAsync(int movieId)
    {
        Watchlist watchlist = new()
        {
            MovieId = movieId,
        };

        await context.Watchlists.AddAsync(watchlist);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        List<MovieDto> movies = await context.Watchlists
            .AsNoTracking()
            .Select(w => new MovieDto
            {
                Id = w.Movie.Id,
                Title = w.Movie.Title,
                Genre = w.Movie.Genre,
                Director = w.Movie.Director,
                ReleaseDate = w.Movie.ReleaseDate,
                Duration = w.Movie.Duration,
                Description = w.Movie.Description,
                ImageUrl = w.Movie.ImageUrl,
            })
            .ToListAsync();

        return movies;
    }

    public async Task RemoveAsync(int movieId)
    {
        Watchlist? watchlist = await context.Watchlists
            .Where(w => w.Movie.Id == movieId)
            .FirstOrDefaultAsync();

        if (watchlist is null) return;

        context.Watchlists.Remove(watchlist);
        await context.SaveChangesAsync();
    }
}
