namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Player
{
    [Key]
    public int PlayerId { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public int SquadNumber { get; set; }

    public bool IsInjured { get; set; }

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }

    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }

    [ForeignKey(nameof(Town))]
    public int TownId { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;

    public virtual Town Town { get; set; } = null!;

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
        = new HashSet<PlayerStatistic>();
}
