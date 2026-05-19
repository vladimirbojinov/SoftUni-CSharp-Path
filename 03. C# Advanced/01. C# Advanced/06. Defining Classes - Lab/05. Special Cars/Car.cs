using System.Text;

namespace CarManufacturer
{
	public class Car
	{
		private string make;
		private string model;
		private int year;
		private int horsePower;
		private double fuelQuantity;
		private Engine engine;

		public Car(string make, string model, int year, int horsePower, double fuelQuantity, Engine engine)
		{
			Make = make;
			Model = model;
			Year = year;
			HorsePower = horsePower;
			FuelQuantity = fuelQuantity;
			Engine = engine;
		}

		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int HorsePower { get; set; }
		public double FuelQuantity { get; set; }
		public Engine Engine { get; set; }

		public override string ToString()
		{
			return $"Make: {Make}\nModel: {Model}\nYear: {Year}\nHorsePowers: {Engine.HorsePower}\nFuelQuantity: {FuelQuantity}";
		}

		public void WhoAmI()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(Make);
			sb.AppendLine(Model);
			sb.AppendLine(Year.ToString());
			sb.AppendLine(HorsePower.ToString());
			sb.AppendLine(Engine.HorsePower.ToString());

            Console.WriteLine(sb);
        }
	}
}
