namespace SocialNetwork.DataProcessor;

using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.Data.Models.Enums;
using SocialNetwork.DataProcessor.ImportDTOs;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using ViJsonTools;
using ViXmlTools;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data format.";
    private const string DuplicatedDataMessage = "Duplicated data.";
    private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
    private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

    public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
    {
        StringBuilder sb = new();

        ImportMessagesDto[] importedMessages = XmlUtilities.Deserialize<ImportMessagesDto>(xmlString, "Messages");

        List<Message> existingMessages = dbContext.Messages.ToList();

        List<int> validConversationsIds = dbContext.Conversations.Select(c => c.Id).ToList();
        List<int> validUserIds = dbContext.Users.Select(u => u.Id).ToList();

        List<Message> persistedMessages = new();
        foreach (ImportMessagesDto messagesDto in importedMessages)
        {
            if (IsValid(messagesDto) == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (DateTime.TryParseExact(
                messagesDto.SentAt,
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime sendAt) == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (Enum.TryParse(messagesDto.Status, out Status status) == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (validConversationsIds.Contains(messagesDto.ConversationId) == false ||
                validUserIds.Contains(messagesDto.SenderId) == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }            

            if (IsMessageDuplicate(persistedMessages, messagesDto, sendAt, status) ||
                IsMessageDuplicate(existingMessages, messagesDto, sendAt, status))
            {
                sb.AppendLine(DuplicatedDataMessage);
                continue;
            }

            Message message = new()
            {
                Content = messagesDto.Content,
                SentAt = sendAt,
                Status = status,
                ConversationId = messagesDto.ConversationId,
                SenderId = messagesDto.SenderId,
            };

            sb.AppendLine(string.Format(SuccessfullyImportedMessageEntity, sendAt.ToString("yyyy-MM-ddTHH:mm:ss"), status));
            persistedMessages.Add(message);
        }

        dbContext.AddRange(persistedMessages);
        dbContext.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
    {
        StringBuilder sb = new();

        ImportPostDto[] importedPost = JsonUtilities.Deserialize<ImportPostDto>(jsonString);

        List<int> validUserIds = dbContext.Users.Select(u => u.Id).ToList();
        List<Post> existingPost = dbContext.Posts.ToList();

        List<Post> persistedPost = new();
        foreach (ImportPostDto postDto in importedPost)
        {
            if (IsValid(postDto) == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (DateTime.TryParseExact(
                    postDto.CreatedAt,
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime createdAt
                ) == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (validUserIds.Contains(postDto.CreatorId) == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (IsPostDuplicate(existingPost, postDto, createdAt) ||
                IsPostDuplicate(persistedPost, postDto, createdAt))
            {
                sb.AppendLine(DuplicatedDataMessage);
                continue;
            }

            Post post = new()
            {
                Content = postDto.Content,
                CreatedAt = createdAt,
                CreatorId = postDto.CreatorId,
            };

            string creatorName = dbContext.Users.Find(postDto.CreatorId).Username;

            persistedPost.Add(post);
            sb.AppendLine(string.Format(SuccessfullyImportedPostEntity, creatorName, createdAt.ToString("yyyy-MM-ddTHH:mm:ss")));
        }

        dbContext.AddRange(persistedPost);
        dbContext.SaveChanges();

        return sb.ToString().Trim();
    }

    public static bool IsValid(object dto)
    {
        ValidationContext validationContext = new ValidationContext(dto);
        List<ValidationResult> validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

        foreach (ValidationResult validationResult in validationResults)
        {
            if (validationResult.ErrorMessage != null)
            {
                string currentMessage = validationResult.ErrorMessage;
            }
        }

        return isValid;
    }

    private static bool IsMessageDuplicate(List<Message> messages, ImportMessagesDto messagesDto, DateTime sendAt, Status status)
    {
        return messages.Any(m => m.Content == messagesDto.Content &&
                                 m.SentAt == sendAt &&
                                 m.Status == status &&
                                 m.SenderId == messagesDto.SenderId);
    }

    private static bool IsPostDuplicate(List<Post> posts, ImportPostDto postDto, DateTime createdAt)
    {
        return posts.Any(p => p.Content.Equals(postDto.Content) &&
                                     p.CreatedAt.Equals(createdAt) &&
                                     p.CreatorId.Equals(postDto.CreatorId));
    }
}
