namespace SocialNetwork.DataProcessor;

using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.DataProcessor.ExportDTOs;
using ViJsonTools;
using ViXmlTools;

public class Serializer
{
    public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
    {
        var export = new ExportUsersWithFriendShipsCountAndTheirPosts()
        {
            Users = dbContext.Users
            .OrderBy(u => u.Username)
            .Select(u => new ExportUserDto()
            {
                Username = u.Username,
                Friendships = dbContext.Friendships
                    .Count(f => f.UserOneId == u.Id || f.UserTwoId == u.Id),
                Posts = u.Posts
                .Select(p => new ExportPostDto()
                {
                    Content = p.Content,
                    CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
                })
                .ToList()
            })
            .ToList()
        };

        return XmlUtilities.Serialize(export, "Users");
    }

    public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
    {
        var export = dbContext.Conversations
            .OrderBy(m => m.StartedAt)
            .Select(c => new
            {
                c.Id,
                c.Title,
                StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                Messages = c.Messages
                .OrderBy(m => m.SentAt)
                .Select(m => new
                {
                    m.Content,
                    SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                    m.Status,
                    SenderUsername = m.Sender.Username
                })
            })
            .ToList();

        return JsonUtilities.Serialize(export);
    }
}
