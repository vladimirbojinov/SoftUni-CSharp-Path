namespace CarDealer;

using DTOs.Export;
using DTOs.Import;
using Models;
using Data;
using Microsoft.EntityFrameworkCore;
using ViXmlTools;

public class StartUp
{
    public static void Main()
    {
        string xmlFile = "sales.xml";
        string xmlInput = File.ReadAllText(XmlUtilities.GetXmlPath(xmlFile));

        CarDealerContext contex = new();
        contex.Database.EnsureCreated();

        string output = GetTotalSalesByCustomer(contex);
        Console.WriteLine(output);
    }

    //09. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        ImportSupplierDto[] importedSuppliers = XmlUtilities.Deserialize<ImportSupplierDto>(inputXml, "Suppliers");

        List<Supplier> suppliers = new();
        foreach (ImportSupplierDto dtoSuplier in importedSuppliers)
        {
            Supplier supplier = new()
            {
                Name = dtoSuplier.Name,
                IsImporter = dtoSuplier.IsImporter,
            };

            suppliers.Add(supplier);
        }

        context.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}";
    }

    //10. Import Parts
    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        ImportPartDto[] importedParts = XmlUtilities.Deserialize<ImportPartDto>(inputXml, "Parts");

        List<Part> parts = new();
        foreach (ImportPartDto dtoPart in importedParts)
        {
            if (!context.Suppliers.Any(p => dtoPart.SupplierId == p.Id)) continue;

            Part part = new()
            {
                Name = dtoPart.Name,
                Price = dtoPart.Price,
                Quantity = dtoPart.Quantity,
                SupplierId = dtoPart.SupplierId,
            };

            parts.Add(part);
        }

        context.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}";
    }

    //11. Import Cars
    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        ImportCarDto[] importedCars = XmlUtilities.Deserialize<ImportCarDto>(inputXml, "Cars");

        List<Car> cars = new();
        foreach (ImportCarDto dtoCar in importedCars)
        {
            Car car = new()
            {
                Make = dtoCar.Make,
                Model = dtoCar.Model,
                TraveledDistance = dtoCar.TraveledDistance,
                PartsCars = dtoCar.Parts
                    .Select(x => x.Id)
                    .Distinct()
                    .Select(id => new PartCar
                    {
                        PartId = id
                    })
                    .ToArray()
            };

            cars.Add(car);
        }

        context.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}";
    }

    //12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        ImportCustomersDto[] importedCustomers = XmlUtilities.Deserialize<ImportCustomersDto>(inputXml, "Customers");

        List<Customer> customers = new();
        foreach (ImportCustomersDto dtoCustomer in importedCustomers)
        {
            Customer customer = new()
            {
                Name = dtoCustomer.Name,
                BirthDate = dtoCustomer.BirthDate,
                IsYoungDriver = dtoCustomer.IsYoungDriver,
            };

            customers.Add(customer);
        }

        context.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}";
    }

    //13. Import Sales
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        ImportSalesDto[] importedSalesDtos = XmlUtilities.Deserialize<ImportSalesDto>(inputXml, "Sales");

        HashSet<int> existingCarIds = context.Cars
            .Select(c => c.Id)
            .ToHashSet();

        List<Sale> sales = new();
        foreach (ImportSalesDto dtoSale in importedSalesDtos)
        {
            if (!existingCarIds.Contains(dtoSale.CarId)) continue;

            Sale sale = new()
            {
                CarId = dtoSale.CarId,
                CustomerId = dtoSale.CustomerId,
                Discount = dtoSale.Discount,
            };

            sales.Add(sale);
        }

        context.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}";
    }

    //14. Export Ordered Customers
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        var cars = context.Cars
            .AsNoTracking()
            .Where(c => c.TraveledDistance > 2_000_000)
            .Select(c => new ExportCarWithDistanceDto
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ToArray();

        return XmlUtilities.Serialize(cars, "cars");
    }

    //15. Export Cars from Make Toyota
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        var bmws = context.Cars
            .AsNoTracking()
            .Where(c => c.Make == "BMW")
            .Select(c => new ExportBmwCarDto
            {
                Id = c.Id,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance
            })
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ToArray();

        return XmlUtilities.Serialize(bmws, "cars");
    }

    //16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var suppliers = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new ExportLocalSupplierDto
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray();

        return XmlUtilities.Serialize(suppliers, "suppliers");
    }

    //17. Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var cars = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .Select(c => new ExportCarWithPartsDto
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                Parts = c.PartsCars
                    .OrderByDescending(pc => pc.Part.Price)
                    .Select(pc => new ExportPartDto
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .ToArray()
            })
            .ToArray();

        return XmlUtilities.Serialize(cars, "cars");
    }

    //18. Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customer = context.Sales;

        return XmlUtilities.Serialize(customer, "customers");
    }

    //19. Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
            .Select(s => new ExportSaleDto
            {
                Car = new ExportSaleCarDto
                {
                    Make = s.Car.Make,
                    Model = s.Car.Model,
                    TraveledDistance = s.Car.TraveledDistance
                },
                Discount = (int)s.Discount,
                CustomerName = s.Customer.Name,
                Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                PriceWithDiscount = (double)Math.Round(
                    s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100),
                    4
                )
            })
            .ToArray();

        return XmlUtilities.Serialize(sales, "sales");
    }
}