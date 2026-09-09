namespace MoviesApp.DTOs.Watchlist;

using System.ComponentModel.DataAnnotations;

public class WatchlistDto
{
    [Required]
    public int MovieId { get; set; }
}
