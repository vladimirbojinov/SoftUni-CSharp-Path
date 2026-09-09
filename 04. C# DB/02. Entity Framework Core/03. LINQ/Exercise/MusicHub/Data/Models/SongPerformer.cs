namespace MusicHub.Data.Models;

using Microsoft.EntityFrameworkCore;

[PrimaryKey(nameof(SongId), nameof(PerformerId))]
public class SongPerformer
{
    public int SongId { get; set; }

    public int PerformerId { get; set; }

    public virtual Song Song { get; set; } = null!;

    public virtual Performer Performer { get; set; } = null!;
}
