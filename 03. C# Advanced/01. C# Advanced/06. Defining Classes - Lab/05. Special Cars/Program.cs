namespace CarManufacturer
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			Dictionary<int, List<(int, double)>> tierMap = new Dictionary<int, List<(int, double)>>();
			FillTierMap(tierMap);

			Dictionary<int, (int, double)> engineMap = new Dictionary<int, (int, double)>();
			FillEngineMap(engineMap);

			List<Car> specialCars = new List<Car>();
			FindSpecial(tierMap, engineMap, specialCars);

            Console.WriteLine(string.Join("\n", specialCars));
        }

		private static void FindSpecial(Dictionary<int, List<(int, double)>> tierMap, Dictionary<int, (int, double)> engineMap, List<Car> specialCars)
		{
			string command;
			while ((command = Console.ReadLine()) != "Show special")
			{
				string[] currenCar = command
					.Split()
					.ToArray();

				string make = currenCar[0];
				string model = currenCar[1];
				int year = int.Parse(currenCar[2]);
				double fuelQuantity = double.Parse(currenCar[3]);
				double fuelConsumption = double.Parse(currenCar[4]);
				int engineIndex = int.Parse(currenCar[5]);
				int tierIndex = int.Parse(currenCar[6]);

				int horsePower = engineMap[engineIndex].Item1;
				double cubicCapacity = engineMap[engineIndex].Item2;

				List<(int, double)> tierData = tierMap[tierIndex];
				double tierPressureSum = tierData.Select(x => x.Item2).Sum();
				
				fuelQuantity -= TestDrive(fuelQuantity, fuelConsumption);

				if (year < 2017 ||
					horsePower < 330 ||
					fuelQuantity < 0 ||
					(tierPressureSum < 9 || tierPressureSum > 10))
				{
					continue;
				}

				Engine engine = new Engine(horsePower, cubicCapacity);
				Car specialCar = new Car(make, model, year, horsePower, fuelQuantity, engine);
				specialCars.Add(specialCar);
			}
		}

		private static double TestDrive(double fuelQuantity, double fuelConsumption)
		{
			double data = (fuelConsumption / 100) * 20;
			return data;
		}

		private static void FillEngineMap(Dictionary<int, (int, double)> engineMap)
		{
			(int, double) engineData;
			int index = -1;

			string command;
			while ((command = Console.ReadLine()) != "Engines done")
			{
				string[] allItem = command
					.Split();
				
				int horsePower = int.Parse(allItem[0]);
				double cubicCapacity = double.Parse(allItem[1]);

				engineData = (horsePower, cubicCapacity);
				
				index++;
				engineMap.Add(index, engineData);
			}
		}

		private static void FillTierMap(Dictionary<int, List<(int, double)>> tierMap)
		{
			List<(int, double)> listItem = new List<(int, double)>();
			int index = -1;

			string command;
			while ((command = Console.ReadLine()) != "No more tires")
			{
				string[] tierData = command
					.Split();

				for (int i = 0; i < tierData.Length; i += 2)
				{
					int year = int.Parse(tierData[i]);
					double pressure = double.Parse(tierData[i + 1]);

					listItem.Add((year, pressure));
				}

				index++;
				tierMap.Add(index, listItem);
				listItem = new List<(int, double)>();
			}
		}
	}
}
