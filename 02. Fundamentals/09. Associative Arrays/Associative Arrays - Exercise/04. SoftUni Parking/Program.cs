namespace _04._SoftUni_Parking
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> registeredCars = new Dictionary<string, string>();

			int registrationNumber = int.Parse(Console.ReadLine());
			for (int i = 0; i < registrationNumber; i++)
			{
				string[] arguments = Console.ReadLine().Split();
				string name = arguments[1];

				switch (arguments[0])
				{
					case "register": RegisterCar(registeredCars, arguments, name); break;
					case "unregister": UnregisterCar(registeredCars, name); break;
				}
			}

			foreach (var car in registeredCars)
			{
				Console.WriteLine($"{car.Key} => {car.Value}");
			}
		}

		private static void UnregisterCar(Dictionary<string, string> registeredCars, string name)
		{
			if (registeredCars.ContainsKey(name))
			{
				registeredCars.Remove(name);
				Console.WriteLine($"{name} unregistered successfully");
			}
			else
			{
				Console.WriteLine($"ERROR: user {name} not found");
			}
		}

		private static void RegisterCar(Dictionary<string, string> registeredCars, string[] arguments, string name)
		{
			string licensePlate = arguments[2];
			if (!registeredCars.ContainsKey(name))
			{
				registeredCars.Add(name, licensePlate);
				Console.WriteLine($"{name} registered {licensePlate} successfully");
			}
			else
			{
				Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
			}
		}
	}
}