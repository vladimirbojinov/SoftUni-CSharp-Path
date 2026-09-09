namespace MoviesApp.Services;

using Microsoft.EntityFrameworkCore;

using Services.Interfaces;

using Data;
using DTOs.Movie;
using Models;

public class MoviesService(AppDbContext context) : IMoviesService
{
    public async Task AddAsync(MovieDto movieDto)
    {
        Movie movie = new()
        {
            Title = movieDto.Title,
            Genre = movieDto.Genre,
            Director = movieDto.Director,
            ReleaseDate = movieDto.ReleaseDate,
            Duration = movieDto.Duration,
            Description = movieDto.Description,
            ImageUrl = movieDto.ImageUrl,
        };

        await context.Movies.AddAsync(movie);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Movie? movie = await context.Movies.FindAsync(id);

        if (movie is null) return;

        context.Movies.Remove(movie);
        await context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
        => await context.Movies.AnyAsync(m => m.Id == id);

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        List<MovieDto> movies = await context.Movies
            .AsNoTracking()
            .Select(m => new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                Director = m.Director,
                ReleaseDate = m.ReleaseDate,
                Duration = m.Duration,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
            })
            .ToListAsync();

        return movies;
    }

    public async Task<MovieDto?> GetByIdAsync(int id)
    {
        Movie? movie = await context.Movies.FindAsync(id);

        if (movie is null) return null;

        MovieDto movieView = new()
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

        return movieView;
    }

    public async Task UpdateAsync(MovieDto movieDto)
    {
        Movie? movie = await context.Movies.FindAsync(movieDto.Id);

        if (movie is null) return;

        movie.Title = movieDto.Title;
        movie.Genre = movieDto.Genre;
        movie.Director = movieDto.Director;
        movie.ReleaseDate = movieDto.ReleaseDate;
        movie.Duration = movieDto.Duration;
        movie.Description = movieDto.Description;
        movie.ImageUrl = movieDto.ImageUrl;

        context.Movies.Update(movie);
        await context.SaveChangesAsync();
    }
}
