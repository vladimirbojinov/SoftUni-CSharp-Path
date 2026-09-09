namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;
using static TravelAgency.Common.ValidationConstants;

public class TourPackage
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(TourPackageNameMaxLenght)]
    public string PackageName { get; set; } = null!;

    [StringLength(TourPackageDescriptionMaxLength)]
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; }
        = new HashSet<Booking>();

    public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
        = new HashSet<TourPackageGuide>();
}
