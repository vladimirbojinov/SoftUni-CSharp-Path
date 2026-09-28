namespace SocialNetwork.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SocialNetwork.Common.ValidationConstants;

public class Post
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(PostContentMaxLength)]
    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(Creator))]
    public int CreatorId { get; set; }

    public User Creator { get; set; } = null!;
}
    