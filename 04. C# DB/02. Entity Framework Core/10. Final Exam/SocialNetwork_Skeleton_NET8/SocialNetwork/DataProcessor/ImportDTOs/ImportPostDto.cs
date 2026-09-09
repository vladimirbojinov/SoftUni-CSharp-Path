namespace SocialNetwork.DataProcessor.ImportDTOs;

using System.ComponentModel.DataAnnotations;
using static SocialNetwork.Common.ValidationConstants;

public class ImportPostDto
{
    [Required]
    [StringLength(PostContentMaxLength, MinimumLength = PostContentMinLength)]
    public string Content { get; set; } = null!;

    [Required]
    public string CreatedAt { get; set; } = null!;

    [Required]
    public int CreatorId { get; set; }
}
