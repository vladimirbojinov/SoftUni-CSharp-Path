using System.Reflection;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> carCatalog = new List<Car>();
            List<Truck> truckCatalog = new List<Truck>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] vehicle = command.Split("/");
                if (vehicle[0] == "Car")
                {
                    string brand = vehicle[1];
                    string model = vehicle[2];
                    string horsePower = vehicle[3];
                    Car car = new Car(brand, model, horsePower);
                    carCatalog.Add(car);
                }
                else
                {
                    string brand = vehicle[1];
                    string model = vehicle[2];
                    string weight = vehicle[3];
                    Truck truck = new Truck(brand, model, weight);
                    truckCatalog.Add(truck);
                }
            }

            if (carCatalog.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car vehicle in carCatalog.OrderBy((x => x.Brand)))
                {
                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.HorsePower}hp");
                }
            }

            if (truckCatalog.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck vehicle in truckCatalog.OrderBy((x => x.Brand)))
                {
                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.Weight}kg");
                }
            }
        }
    }

    public class Truck
    {
        public Truck(string brand, string model, string weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
    }

    public class Car
    {
        public Car(string brand, string model, string horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

    public class Catalog
    {
        public Catalog(Car carCatallog, Truck truckCatallog)
        {
            CarCatallog = carCatallog;
            TruckCatallog = truckCatallog;
        }

        public Car CarCatallog { get; set; }
        public Truck TruckCatallog { get; set; }
    }
}