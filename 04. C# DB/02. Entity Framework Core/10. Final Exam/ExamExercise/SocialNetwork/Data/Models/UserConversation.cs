namespace SocialNetwork.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(UserId), nameof(ConversationId))]
public class UserConversation
{
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    [ForeignKey(nameof(Conversation))]
    public int ConversationId { get; set; }

    public User User { get; set; } = null!;

    public Conversation Conversation { get; set; } = null!;
}
