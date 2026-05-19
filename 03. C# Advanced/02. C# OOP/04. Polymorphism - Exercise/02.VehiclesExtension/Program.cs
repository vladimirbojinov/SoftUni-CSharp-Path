using _02.VehiclesExtension.Interfaces;
using _02.VehiclesExtension.Vehicles;

namespace _02.VehiclesExtension;

internal class Program
{
	static void Main(string[] args)
	{
		string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
		double fuelQuantity = double.Parse(data[1]);
		double litersPerKm = double.Parse(data[2]);
		double tankCapacity = double.Parse(data[3]);
		Car car = new Car(fuelQuantity, litersPerKm, tankCapacity);

		data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
		fuelQuantity = double.Parse(data[1]);
		litersPerKm = double.Parse(data[2]);
		tankCapacity = double.Parse(data[3]);
		Truck truck = new Truck(fuelQuantity, litersPerKm, tankCapacity);

		data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
		fuelQuantity = double.Parse(data[1]);
		litersPerKm = double.Parse(data[2]);
		tankCapacity = double.Parse(data[3]);
		Bus bus = new Bus(fuelQuantity, litersPerKm, tankCapacity);


		int commandCount = int.Parse(Console.ReadLine());
		for (int i = 0; i < commandCount; i++)
		{
			string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
			if (command[0] == "Drive" || command[0] == "DriveEmpty")
			{
				double distance = double.Parse(command[2]);
				switch (command[1])
				{
					case "Car": Drive(car, distance, true); break;
					case "Truck": Drive(truck, distance, true); break;
					case "Bus": IsBusEmpty(bus, distance, command[0]); break;
				}
			}
			else if (command[0] == "Refuel")
			{
				double fuel = double.Parse(command[2]);
				switch (command[1])
				{
					case "Car": Refuel(car, fuel); break;
					case "Truck": Refuel(truck, fuel); break;
					case "Bus": Refuel(truck, fuel); break;
				}
			}
		}

		Console.WriteLine($"Car: {car.FuelQuantity:F2}");
		Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
		Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
	}

	private static void IsBusEmpty(Bus bus, double distance, string busCondition)
	{
		switch (busCondition)
		{
			case "Drive": Drive(bus, distance, true); break;
			case "DriveEmpty": Drive(bus, distance, false); break;
		}
	}

	public static void Drive(IDrive vehicle, double distance, bool isAcOn)
	{
		try
		{
			vehicle.Drive(distance, isAcOn);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
	public static void Refuel(IRefuel vehicle, double fuel)
	{
		try
		{
			vehicle.Refuel(fuel);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
