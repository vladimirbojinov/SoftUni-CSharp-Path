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