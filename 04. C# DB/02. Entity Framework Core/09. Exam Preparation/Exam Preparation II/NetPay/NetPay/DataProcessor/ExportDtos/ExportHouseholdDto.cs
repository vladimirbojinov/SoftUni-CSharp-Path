using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos;

public class ExportHouseholdDto
{
    [XmlElement("ContactPerson")]
    public string ContactPerson { get; set; }

    [XmlElement("Email")]
    public string Email { get; set; }

    [XmlElement("PhoneNumber")]
    public string PhoneNumber { get; set; }

    [XmlArray("Expenses")]
    [XmlArrayItem("Expense")]
    public List<ExportExpenseDto> Expenses { get; set; } = new();
}
