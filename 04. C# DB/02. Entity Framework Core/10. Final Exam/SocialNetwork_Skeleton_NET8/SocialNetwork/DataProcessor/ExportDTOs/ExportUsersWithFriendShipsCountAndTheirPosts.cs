namespace SocialNetwork.DataProcessor.ExportDTOs;

using System.Xml.Serialization;

public class ExportUsersWithFriendShipsCountAndTheirPosts
{
    [XmlElement("User")]
    public List<ExportUserDto> Users { get; set; } = null!;
}
