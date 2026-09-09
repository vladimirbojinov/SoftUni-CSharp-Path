namespace TravelAgency.DataProcessor.ExportDtos;

using System.Xml.Serialization;

public class ExportGuideDto
{
    [XmlElement("FullName")]
    public string FullName { get; set; }

    [XmlArray("TourPackages")]
    [XmlArrayItem("TourPackage")]
    public List<ExportTourPackageDto> TourPackages { get; set; }
}
