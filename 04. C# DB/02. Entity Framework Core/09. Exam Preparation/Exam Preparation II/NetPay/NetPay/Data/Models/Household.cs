namespace NetPay.Data.Models;

using System.ComponentModel.DataAnnotations;
using static NetPay.Common.ValidationConstants;

public class Household
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(HouseholdContactPersonMaxLength)]
    public string ContactPerson { get; set; } = null!;

    [StringLength(HouseholdEmailMaxLength)]
    public string? Email { get; set; }

    [Required]
    [StringLength(HouseholdPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; }
        = new HashSet<Expense>();
}
