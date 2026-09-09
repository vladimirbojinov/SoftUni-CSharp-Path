namespace TravelAgency.DataProcessor;

using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using ViJsonTools;
using ViXmlTools;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Serializer
{
    public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
    {
        ExportGuidesWithSpanishLanguageWithAllTheirTourPackagesDto export = new()
        {
            Guides = context.Guides
            .Where(g => g.Language == Language.Spanish)
            .OrderByDescending(g => g.TourPackagesGuides.Count)
            .ThenBy(g => g.FullName)
            .Select(g => new ExportGuideDto
            {
                FullName = g.FullName,
                TourPackages = g.TourPackagesGuides.Select(tpg => new ExportTourPackageDto
                {
                    Name = tpg.TourPackage.PackageName,
                    Description = tpg.TourPackage.Description,
                    Price = tpg.TourPackage.Price,
                })
                .OrderByDescending(tpg => tpg.Price)
                .ToList()
            }).ToList()
        };

        return XmlUtilities.Serialize(export, "Guides");
    }

    public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
    {
        string packageFilter = "Horse Riding Tour";

        var export = context.Customers
            .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == packageFilter))
            .Select(c => new
            {
                c.FullName,
                c.PhoneNumber,
                Bookings = c.Bookings
                .OrderBy(b => b.BookingDate)
                .Select(b => new
                {
                    TourPackageName = b.TourPackage.PackageName,
                    Date = b.BookingDate.ToString("yyyy-MM-dd")
                })
                .Where(b => b.TourPackageName == packageFilter)
                .ToArray()
            })
            .OrderByDescending(c => c.Bookings.Length)
            .ThenBy(c => c.FullName)
            .ToArray();

        return JsonUtilities.Serialize(export);
    }
}
