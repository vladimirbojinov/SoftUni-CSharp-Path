namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Producer
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    [Required]
    public string Name { get; set; } = null!;

    public string? Pseudonym { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Album> Albums { get; set; }
        = new HashSet<Album>();
}
