namespace SocialNetwork.DataProcessor.ExportDTOs;

using System.Xml.Serialization;

public class ExportPostDto
{
    [XmlElement("Content")]
    public string Content { get; set; }

    [XmlElement("CreatedAt")]
    public string CreatedAt { get; set; }
}
