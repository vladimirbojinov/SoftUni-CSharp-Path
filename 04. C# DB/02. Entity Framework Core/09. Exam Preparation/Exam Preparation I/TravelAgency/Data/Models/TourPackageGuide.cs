namespace TravelAgency.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

[PrimaryKey(nameof(TourPackageId), nameof(GuideId))]
public class TourPackageGuide
{
    [ForeignKey(nameof(TourPackage))]
    public int TourPackageId { get; set; }

    [ForeignKey(nameof(Guide))]
    public int GuideId { get; set; }

    public virtual TourPackage TourPackage { get; set; } = null!;

    public virtual Guide Guide { get; set; } = null!;
}
