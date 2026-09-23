namespace GarageApp.Data.Configuration;

using GarageApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GarageConfiguration : IEntityTypeConfiguration<Garage>
{
    public void Configure(EntityTypeBuilder<Garage> builder)
    {
        builder.HasData(
            new Garage
            {
                Id = 1,
                Name = "Downtown Motors",
                Location = "123 Main Street"
            },
            new Garage
            {
                Id = 2,
                Name = "Suburban Auto Hub",
                Location = "456 Oak Avenue"
            },
            new Garage
            {
                Id = 3,
                Name = "Elite Performance Center",
                Location = "789 Speedway Blvd"
            }
        );
    }
}
