namespace DefiningClasses;

public class Engine
{
	private string model;
	private int power;
	private int displacement;
	private string efficiency;

	public Engine(string model, int power, int? displacement, string? efficiency = null)
	{
		Model = model;
		Power = power;
		Displacement = displacement;
		Efficiency = efficiency;
	}

	public Engine(string model, int power, string efficiency) : this(model, power, null, efficiency) { }

	public Engine(string model, int power, int displacement) : this(model, power, displacement, null) { }

	public string Model { get; set; }
	public int Power { get; set; }
	public int? Displacement { get; set; }
	public string? Efficiency { get; set; }
}
