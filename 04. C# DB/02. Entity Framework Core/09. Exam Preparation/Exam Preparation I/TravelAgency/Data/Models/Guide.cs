namespace TravelAgency.Data.Models;

using System.ComponentModel.DataAnnotations;
using TravelAgency.Data.Models.Enums;
using static TravelAgency.Common.ValidationConstants;

public class Guide
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(GuideFullNameMaxLength)]
    public string FullName { get; set; } = null!;
    
    public Language Language { get; set; }

    public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
        = new HashSet<TourPackageGuide>();
}
