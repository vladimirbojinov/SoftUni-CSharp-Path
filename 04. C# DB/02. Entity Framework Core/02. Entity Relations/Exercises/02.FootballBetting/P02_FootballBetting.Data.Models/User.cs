namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string Username { get; set; } = null!;

    public string? Name { get; set; }

    [Required]
    public string Password { get; set; } = null!;

    public string? Email { get; set; }

    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
        = new HashSet<Bet>();
}
