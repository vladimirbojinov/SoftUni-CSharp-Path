using Microsoft.EntityFrameworkCore;

namespace P02_FootballBetting.Data.Models;

[PrimaryKey(nameof(GameId), nameof(PlayerId))]
public class PlayerStatistic
{
    public int GameId { get; set; }

    public int PlayerId { get; set; }

    public int ScoredGoals { get; set; }

    public int Assists { get; set; }

    public int MinutesPlayed { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
