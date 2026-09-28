namespace BookShelf.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    public int Year { get; set; }

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }

    public string? ImageUrl { get; set; }

    public Author Author { get; set; } = null!;
}
