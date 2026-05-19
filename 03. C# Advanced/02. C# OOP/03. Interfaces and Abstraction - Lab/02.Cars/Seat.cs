namespace Cars;

internal class Seat : ICar
{
	public Seat(string model, string color)
	{
		this.Model = model;
		this.Color = color;
	}

	public string Model { get; }

	public string Color { get; }

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
		return $"{this.Color} Seat {this.Model}";
	}
}
