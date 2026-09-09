namespace SocialNetwork.Data.Models;

using SocialNetwork.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using static SocialNetwork.Common.ValidationConstants;

public class Message
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(MessageContentMaxLength)]
    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public Status Status { get; set; }

    [ForeignKey(nameof(Conversation))]
    public int ConversationId { get; set; }

    [ForeignKey(nameof(Sender))]
    public int SenderId { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
