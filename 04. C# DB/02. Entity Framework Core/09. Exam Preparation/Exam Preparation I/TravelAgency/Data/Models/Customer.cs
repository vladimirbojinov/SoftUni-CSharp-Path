namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;
using static TravelAgency.Common.ValidationConstants;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(CustomerFullNameMaxLength)]
    public string FullName { get; set; } = null!;

    [Required]
    [StringLength(CustomerEmailMaxLength)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(CustomerPhoneNumberLength)]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; }
        = new HashSet<Booking>();
}
