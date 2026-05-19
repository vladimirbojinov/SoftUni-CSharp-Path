namespace Cars;

internal class Tesla : ICar, IElectricCar
{
	public Tesla(string model, string color, int battery)
	{
		Model = model;
		Color = color;
		Battery = battery;
	}

	public string Model { get; }

	public string Color { get; }

	public int Battery { get; }

	public void Start()
	{
		Console.WriteLine("Engine start");
	}

	public void Stop()
	{
		Console.WriteLine("Breaaak!");
	}

	public override string ToString()
	{
		return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries";
	}
}
