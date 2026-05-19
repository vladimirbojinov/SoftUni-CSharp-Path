using _01.Vehicles.Interfaces;
using _01.Vehicles.Vehicle;

namespace _01.Vehicles;

public class Program
{
	static void Main(string[] args)
	{
		string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
		double fuelQuantity = double.Parse(data[1]);
		double litersPerKm = double.Parse(data[2]);
		Car car = new Car(fuelQuantity, litersPerKm);

		data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
		fuelQuantity = double.Parse(data[1]);
		litersPerKm = double.Parse(data[2]);
		Truck truck = new Truck(fuelQuantity, litersPerKm);


		int commandCount = int.Parse(Console.ReadLine());
		for (int i = 0; i < commandCount; i++)
		{
			string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
			if (command[0] == "Drive")
			{
				double distance = double.Parse(command[2]);
				switch (command[1])
				{
					case "Car": Drive(car, distance); break;
					case "Truck": Drive(truck, distance); break;
				}
			}
			else if (command[0] == "Refuel")
			{
				double fuel = double.Parse(command[2]);
				switch (command[1])
				{
					case "Car": Refuel(car, fuel); break;
					case "Truck": Refuel(truck, fuel); break;
				}
			}
		}

		Console.WriteLine($"Car: {car.FuelQuantity:F2}");
		Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
	}

	public static void Drive(IDrive vehicle, double distance)
	{
		try
		{
			vehicle.Drive(distance);
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
