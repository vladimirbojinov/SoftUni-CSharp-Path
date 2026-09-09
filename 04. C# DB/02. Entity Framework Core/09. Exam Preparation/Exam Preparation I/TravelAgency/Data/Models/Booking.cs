namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    [Key]
    public int Id { get; set; }

    public DateTime BookingDate { get; set; }

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    [ForeignKey(nameof(TourPackage))]
    public int TourPackageId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual TourPackage TourPackage { get; set; } = null!;
}
