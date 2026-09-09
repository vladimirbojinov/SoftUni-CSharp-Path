namespace SocialNetwork.Data.Models;

using System.ComponentModel.DataAnnotations;
using static SocialNetwork.Common.ValidationConstants;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(UserUsernameMaxLength)]
    public string Username { get; set; } = null!;

    [Required]
    [StringLength(UserUsernameMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; }
        = new HashSet<Post>();

    public virtual ICollection<Message> Messages { get; set; }
        = new HashSet<Message>();

    public virtual ICollection<UserConversation> UsersConversations { get; set; }
        = new HashSet<UserConversation>();
}
