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
		private Engine engine;
		private Tire[] tires;

		public Car()
		{
			Make = "VW";
			Model = "Golf";
			Year = 2025;
			FuelQuantity = 200;
			FuelConsumption = 10;
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

		public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
		: this (make, model, year, fuelQuantity, fuelConsumption)
		{
			Engine = engine;
			Tires = tires;
		}

		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public double FuelQuantity { get; set; }
		public double FuelConsumption { get; set; }
		public Engine Engine { get; set; }
		public Tire[] Tires { get; set; }

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

			sb.AppendLine($"Make: {Make}");
			sb.AppendLine($"Model: {Model}");
			sb.AppendLine($"Year: {Year}");
			sb.AppendLine($"Fuel: {FuelQuantity:F2}");

			return sb.ToString();
		}
	}
}
