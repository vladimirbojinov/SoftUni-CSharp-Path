using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos;

public class ExportGuidesWithSpanishLanguageWithAllTheirTourPackagesDto
{
    [XmlElement("Guide")]
    public List<ExportGuideDto> Guides { get; set; }
}
