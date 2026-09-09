namespace MoviesApp.Services.Interfaces;

using MoviesApp.DTOs.Movie;

public interface IWatchlistService
{
    Task<IEnumerable<MovieDto>> GetAllAsync();

    Task AddAsync(int movieId);

    Task RemoveAsync(int movieId);
}
