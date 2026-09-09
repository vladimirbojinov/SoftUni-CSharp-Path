using MoviesApp.Common;

namespace MoviesApp.Services;

using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.DTOs.Json;
using MoviesApp.Models;
using MoviesApp.Services.Interfaces;
using ViJsonTools;
using static AppConstants;

public class ImportService(AppDbContext context, IConfiguration appConfiguration) : IImportService
{
    public async Task<int> ImportFromJsonAsync(string file)
    {
        string? datasetPath = appConfiguration.GetValue<string>("DataSet:Path");

        string fullPath = Path.Combine(datasetPath, file);
        if (!File.Exists(fullPath))
            throw new InvalidOperationException($"{file} could not be found!");

        string input = await File.ReadAllTextAsync(fullPath);
        ImportMovieDto[] importedMovies = await JsonUtilities.DeserializeAsync<ImportMovieDto>(input);

        List<Movie> movies = new();
        foreach (ImportMovieDto movieDto in importedMovies)
        {
            bool movieExist = await context.Movies
                .AsNoTracking()
                .AnyAsync(m => m.Title == m.Title);

            if (!movieExist) continue;

            Movie movie = new()
            {
                Title = movieDto.Title,
                Genre = movieDto.Genre,
                ReleaseDate = movieDto.ReleaseDate,
                Director = movieDto.Director,
                Duration = movieDto.Duration,
                Description = movieDto.Description,
                ImageUrl = string.IsNullOrWhiteSpace(movieDto.ImageUrl) ?
                    DefaultImageUrl :
                    movieDto.ImageUrl,
            };

            movies.Add(movie);
        }

        await context.AddRangeAsync(movies);
        await context.SaveChangesAsync();

        return movies.Count();
    }

    public async Task<int> ImportFromXmlAsync(string filePath)
    {
        throw new NotImplementedException();
    }
}
