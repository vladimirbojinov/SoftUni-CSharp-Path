using System.Xml.Serialization;

namespace NetPay.DataProcessor.ExportDtos;

public class ExportExpenseDto
{
    [XmlElement("ExpenseName")]
    public string ExpenseName { get; set; }

    [XmlElement("Amount")]
    public decimal Amount { get; set; }

    [XmlElement("PaymentDate")]
    public string PaymentDate { get; set; }

    [XmlElement("ServiceName")]
    public string ServiceName { get; set; }
}
