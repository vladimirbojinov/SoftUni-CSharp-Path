namespace SocialNetwork.DataProcessor.ImportDTOs;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static SocialNetwork.Common.ValidationConstants;

[XmlType("Message")]
public class ImportMessagesDto
{
    [Required]
    [XmlElement("Content")]
    [StringLength(MessageContentMaxLength, MinimumLength = MessageContentMinLength)]
    public string Content { get; set; } = null!;

    [Required]
    [XmlAttribute("SentAt")]
    public string SentAt { get; set; } = null!;

    [Required]
    [XmlElement("Status")]
    public string Status { get; set; } = null!;

    [Required]
    [XmlElement("ConversationId")]
    public int ConversationId { get; set; }

    [Required]
    [XmlElement("SenderId")]
    public int SenderId { get; set; }
}
