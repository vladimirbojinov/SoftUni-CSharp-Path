using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models;

public class Writer
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Required]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? Pseudonym { get; set; }

    public virtual ICollection<Song> Songs { get; set; }
        = new HashSet<Song>();
}
