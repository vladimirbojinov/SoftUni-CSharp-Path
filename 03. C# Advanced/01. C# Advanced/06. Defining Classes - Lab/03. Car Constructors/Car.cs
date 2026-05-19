using System.Reflection;
using System.Text;

namespace CarManufacturer
{
	class Car
	{
		private string make;
		private string model;
		private int year;
		private double fuelQuantity;
		private double fuelConsumption;

		public Car()
		{
			Make = "VW";
			Model = "Golf";
			Year = 2025;
			FuelQuantity = 200;
			FuelConsumption = 10;
			Console.WriteLine(WhoAmI());
		}

		public Car(string make, string model, int year) 
		: this()
		{
			Make = make;
			Model = model;
			Year = year;
		}

		public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) 
		: this(make, model, year)
		{
			FuelQuantity = fuelQuantity;
			FuelConsumption = fuelConsumption;
		}

		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public double FuelQuantity { get; set; }
		public double FuelConsumption { get; set; }

		public void Drive(double distance)
		{
			double fuelAfterDistance = (FuelQuantity - distance) * FuelConsumption;

			if (fuelAfterDistance < 0)
			{
				Console.WriteLine("Not enough fuel to perform this trip!");
				return;
			}

			FuelQuantity -= fuelAfterDistance;
		}

		public string WhoAmI()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"Make: {this.Make}");
			sb.AppendLine($"Model: {Model}");
			sb.AppendLine($"Year: {Year}");
			sb.AppendLine($"Fuel: {FuelQuantity:F2}");

			return sb.ToString();
		}
}
}
