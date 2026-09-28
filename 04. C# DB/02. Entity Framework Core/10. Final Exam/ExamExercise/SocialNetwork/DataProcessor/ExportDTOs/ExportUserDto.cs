using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ExportDTOs;

public class ExportUserDto
{
    [XmlElement("Username")]
    public string Username { get; set; }

    [XmlAttribute("Friendships")]
    public int Friendships { get; set; }

    [XmlArray("Posts")]
    [XmlArrayItem("Post")]
    public List<ExportPostDto> Posts { get; set; }
}
