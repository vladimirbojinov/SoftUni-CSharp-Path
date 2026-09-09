namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Game
{
    [Key]
    public int GameId { get; set; }

    [ForeignKey(nameof(HomeTeam))]
    public int HomeTeamId { get; set; }

    [ForeignKey(nameof(AwayTeam))]
    public int AwayTeamId { get; set; }

    public int HomeTeamGoals { get; set; }

    public int AwayTeamGoals { get; set; }

    public decimal HomeTeamBetRate { get; set; }

    public decimal AwayTeamBetRate { get; set; }

    public decimal DrawBetRate { get; set; }

    public DateTime DateTime { get; set; }

    [Required]
    public string Result { get; set; } = null!;

    public virtual Team HomeTeam { get; set; } = null!;

    public virtual Team AwayTeam { get; set; } = null!;

    public virtual ICollection<Bet> Bets { get; set; }
        = new HashSet<Bet>();

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; }
        = new HashSet<PlayerStatistic>();
}
