namespace GarageApp.Data.Configuration;

using GarageApp.Data.Enums;
using GarageApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(
            new Car
            {
                Id = 1,
                Make = "Audi",
                Model = "A4",
                Year = 2016,
                Type = CarType.Sedan,
                IsAvailable = true,
                GarageId = 1
            },
            new Car
            {
                Id = 2,
                Make = "BMW",
                Model = "X5",
                Year = 2020,
                Type = CarType.SUV,
                IsAvailable = false,
                GarageId = 1
            },
            new Car
            {
                Id = 3,
                Make = "Toyota",
                Model = "Corolla",
                Year = 2018,
                Type = CarType.Sedan,
                IsAvailable = true,
                GarageId = 2
            },
            new Car
            {
                Id = 4,
                Make = "Ford",
                Model = "Mustang",
                Year = 2021,
                Type = CarType.Coupe,
                IsAvailable = true,
                GarageId = 3
            },
            new Car
            {
                Id = 5,
                Make = "Tesla",
                Model = "Model Y",
                Year = 2023,
                Type = CarType.SUV,
                IsAvailable = false,
                GarageId = 2
            }
        );
    }
}
