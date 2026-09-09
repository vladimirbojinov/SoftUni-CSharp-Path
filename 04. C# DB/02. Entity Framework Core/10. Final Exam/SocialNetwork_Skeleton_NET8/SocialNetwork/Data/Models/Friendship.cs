namespace SocialNetwork.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(UserOneId), nameof(UserTwoId))]
public class Friendship
{
    [ForeignKey(nameof(UserOne))]
    public int UserOneId { get; set; }

    [ForeignKey(nameof(UserTwo))]
    public int UserTwoId { get; set; }

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual User UserOne { get; set; } = null!;

    [DeleteBehavior(DeleteBehavior.Restrict)]
    public virtual User UserTwo { get; set; } = null!;
}
