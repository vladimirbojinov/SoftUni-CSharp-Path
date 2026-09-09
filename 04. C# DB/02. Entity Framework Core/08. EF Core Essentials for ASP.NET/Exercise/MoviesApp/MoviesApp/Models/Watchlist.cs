namespace MoviesApp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Watchlist
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("MovieId")]
    public int MovieId { get; set; }

    public virtual Movie Movie { get; set; } = null!;
}
