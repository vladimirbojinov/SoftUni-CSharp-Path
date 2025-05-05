using System.Reflection;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleCatalog catalog = new VehicleCatalog();

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
                    catalog.Cars.Add(car);
                }
                else
                {
                    string brand = vehicle[1];
                    string model = vehicle[2];
                    string weight = vehicle[3];
                    Truck truck = new Truck(brand, model, weight);
					catalog.Trucks.Add(truck);
				}
            }

            if (catalog.Cars.Count != 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car vehicle in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{vehicle.Brand}: {vehicle.Model} - {vehicle.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Count != 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck vehicle in catalog.Trucks.OrderBy((x => x.Brand)))
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

	public class VehicleCatalog
	{
		public VehicleCatalog()
		{
			Cars = new List<Car>();
            Trucks = new List<Truck>();
		}

		public List<Car> Cars { get; set; }
		public List<Truck> Trucks { get; set; }
	}
}