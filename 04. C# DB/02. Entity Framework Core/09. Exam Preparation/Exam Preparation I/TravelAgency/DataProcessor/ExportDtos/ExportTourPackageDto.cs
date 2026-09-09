namespace TravelAgency.DataProcessor.ExportDtos;

using System.Xml.Serialization;

public class ExportTourPackageDto
{
    [XmlElement("Name")]
    public string Name { get; set; }

    [XmlElement("Description")]
    public string Description { get; set; }

    [XmlElement("Price")]
    public decimal Price { get; set; }
}
