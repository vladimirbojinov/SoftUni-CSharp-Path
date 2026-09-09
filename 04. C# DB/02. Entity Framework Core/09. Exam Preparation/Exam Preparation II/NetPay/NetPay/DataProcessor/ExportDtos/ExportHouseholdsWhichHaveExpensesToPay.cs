namespace NetPay.DataProcessor.ExportDtos;

using System.Xml.Serialization;

public class ExportHouseholdsWhichHaveExpensesToPay
{
    [XmlElement("Household")]
    public List<ExportHouseholdDto> Households { get; set; } = new();
}
