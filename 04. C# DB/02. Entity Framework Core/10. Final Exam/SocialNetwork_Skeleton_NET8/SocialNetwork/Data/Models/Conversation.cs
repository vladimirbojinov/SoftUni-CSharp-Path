namespace SocialNetwork.Data.Models;

using System.ComponentModel.DataAnnotations;
using static SocialNetwork.Common.ValidationConstants;

public class Conversation
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(ConversationTitleMaxLength)]
    public string Title { get; set; } = null!;

    public DateTime StartedAt { get; set; }

    public virtual ICollection<Message> Messages { get; set; } 
        = new HashSet<Message>();

    public virtual ICollection<UserConversation> UsersConversations { get; set; }
        = new HashSet<UserConversation>();
}
