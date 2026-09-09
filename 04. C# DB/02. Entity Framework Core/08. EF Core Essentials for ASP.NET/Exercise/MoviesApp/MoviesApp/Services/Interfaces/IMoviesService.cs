namespace MoviesApp.Services.Interfaces;

using MoviesApp.DTOs.Movie;

public interface IMoviesService
{
    Task<IEnumerable<MovieDto>> GetAllAsync();

    Task<MovieDto?> GetByIdAsync(int id);

    Task AddAsync(MovieDto movie);

    Task UpdateAsync(MovieDto movie);

    Task DeleteAsync(int id);

    Task<bool> ExistsAsync(int id);
}
