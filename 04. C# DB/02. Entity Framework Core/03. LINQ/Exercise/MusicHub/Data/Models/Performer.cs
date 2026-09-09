namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Performer
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Required]
    public string FirstName { get; set; } = null!;

    [StringLength(20)]
    [Required]
    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public decimal NetWorth { get; set; }

    public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
        = new HashSet<SongPerformer>();
}
