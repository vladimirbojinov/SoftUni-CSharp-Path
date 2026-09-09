namespace TravelAgency.DataProcessor.ImportDtos;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static TravelAgency.Common.ValidationConstants;

[XmlType("Customer")]
public class ImportCustomersDto
{
    [Required]
    [XmlElement("FullName")]
    [StringLength(CustomerFullNameMaxLength, MinimumLength = CustomerFullNameMinLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [XmlElement("Email")]
    [StringLength(CustomerEmailMaxLength, MinimumLength = CustomerEmailMinLength)]
    public string Email { get; set; } = null!;

    [Required]
    [XmlAttribute("phoneNumber")]
    [RegularExpression(CustomerPhoneNumberPattern)]
    [StringLength(CustomerPhoneNumberLength, MinimumLength = CustomerPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;
}
