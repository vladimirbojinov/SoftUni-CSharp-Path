namespace CarDealer;

using Data;
using DTOs.Import;
using Microsoft.EntityFrameworkCore;
using Models;
using ViJsonTools;

public class StartUp
{
    public static void Main()
    {
        string jsonFile = "sales.json";
        string jsonInput = File.ReadAllText(JsonUtilities.GetJsonPath(jsonFile));

        CarDealerContext contex = new();
        contex.Database.EnsureCreated();

        string output = GetSalesWithAppliedDiscount(contex);
        Console.WriteLine(output);
    }

    //09. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        ImportSupplierDto[] importedSuppliers = JsonUtilities.Deserialize<ImportSupplierDto>(inputJson);

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

        return $"Successfully imported {suppliers.Count}.";
    }

    //10. Import Parts
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        ImportPartDto[] importedParts = JsonUtilities.Deserialize<ImportPartDto>(inputJson);

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

        return $"Successfully imported {parts.Count}.";
    }

    //11. Import Cars
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        ImportCarDto[] importedCars = JsonUtilities.Deserialize<ImportCarDto>(inputJson);

        List<Car> cars = new();
        foreach (ImportCarDto dtoCar in importedCars)
        {
            Car car = new()
            {
                Make = dtoCar.Make,
                Model = dtoCar.Model,
                TraveledDistance = dtoCar.TraveledDistance,
                PartsCars = dtoCar.PartsId
                .Distinct()
                .Select(x => new PartCar
                {
                    PartId = x
                })
                .ToArray()
            };

            cars.Add(car);
        }

        context.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }

    //12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        ImportCustomersDto[] importedCustomers = JsonUtilities.Deserialize<ImportCustomersDto>(inputJson);

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

        return $"Successfully imported {customers.Count}.";
    }

    //13. Import Sales
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        ImportSalesDto[] importedSales = JsonUtilities.Deserialize<ImportSalesDto>(inputJson);

        List<Sale> sales = new();
        foreach (ImportSalesDto dtoSale in importedSales)
        {
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

        return $"Successfully imported {sales.Count}.";
    }

    //14. Export Ordered Customers
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var users = context.Customers
            .AsNoTracking()
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .AsEnumerable()
            .Select(c => new
            {
                c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                c.IsYoungDriver
            })
            .ToArray();

        return JsonUtilities.Serialize(users);
    }

    //15. Export Cars from Make Toyota
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var toyotas = context.Cars
            .AsNoTracking()
            .Select(c => new
            {
                c.Id,
                c.Make,
                c.Model,
                c.TraveledDistance
            })
            .Where(c => c.Make == "Toyota")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ToArray();

        return JsonUtilities.Serialize(toyotas);
    }

    //16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var localSuppliers = context.Suppliers
            .AsNoTracking()
            .Where(s => s.IsImporter == false)
            .Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray();

        return JsonUtilities.Serialize(localSuppliers);
    }

    //17. Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var cars = context.Cars
            .AsNoTracking()
            .Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                },
                parts = c.PartsCars.Select(pc => new
                {
                    pc.Part.Name,
                    Price = pc.Part.Price.ToString("F2")
                })
                .ToArray()
            })
            .ToArray();

        return JsonUtilities.Serialize(cars);
    }

    //18. Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customers = context.Customers
            .AsNoTracking()
            .Where(c => c.Sales.Count >= 1)
            .Select(c => new
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.Sales
                    .SelectMany(s => s.Car.PartsCars)
                    .Sum(pc => pc.Part.Price)
            })
            .OrderByDescending(c => c.SpentMoney)
            .ThenByDescending(c => c.BoughtCars)
            .ToArray();

        return JsonUtilities.Serialize(customers);
    }

    //19. Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
            .AsNoTracking()
            .Select(s => new
            {
                car = new
                {
                    s.Car.Make,
                    s.Car.Model,
                    s.Car.TraveledDistance
                },
                customerName = s.Customer.Name,
                discount = s.Discount.ToString("F2"),
                price = (s.Car.PartsCars.Sum(pc => pc.Part.Price)).ToString("F2"),
                priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString("F2")
            })
            .Take(10)
            .ToArray();

        return JsonUtilities.Serialize(sales);
    }
}