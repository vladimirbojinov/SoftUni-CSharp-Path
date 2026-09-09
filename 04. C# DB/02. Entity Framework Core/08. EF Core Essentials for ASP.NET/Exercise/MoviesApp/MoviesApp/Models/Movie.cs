namespace MoviesApp.Models;

using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Genre { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }

    [Required]
    [MaxLength(250)]
    public string Director { get; set; } = null!;

    public int Duration { get; set; }

    [Required]
    [MaxLength(1000)]
    public string Description { get; set; } = null!;

    [Required]
    public string? ImageUrl { get; set; }
}
