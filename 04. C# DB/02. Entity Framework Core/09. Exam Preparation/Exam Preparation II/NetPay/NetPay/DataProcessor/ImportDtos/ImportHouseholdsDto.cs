namespace NetPay.DataProcessor.ImportDtos;

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using static NetPay.Common.ValidationConstants;

[XmlType("Household")]
public class ImportHouseholdsDto
{
    [Required]
    [XmlElement("ContactPerson")]
    [StringLength(HouseholdContactPersonMaxLength, MinimumLength = HouseholdContactPersonMinLength)]
    public string ContactPerson { get; set; } = null!;

    [XmlElement("Email")]
    [StringLength(HouseholdEmailMaxLength, MinimumLength = HouseholdEmailMinLength)]
    public string? Email { get; set; }

    [Required]
    [XmlAttribute("phone")]
    [RegularExpression(HouseholdPhoneNumberPattern)]
    [StringLength(HouseholdPhoneNumberLength, MinimumLength = HouseholdPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;
}
