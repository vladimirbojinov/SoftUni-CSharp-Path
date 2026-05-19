namespace DefiningClasses;

public class Car
{
	private string model;
	private Engine engine;
	private Cargo cargo;
	private Tire[] tiers;

	public Car(string model, Engine engine, Cargo cargo, Tire[] tiers)
	{
		Model = model;
		Engine = engine;
		Cargo = cargo;
		Tiers = tiers;
	}

	public string Model { get; set; }
	public Engine Engine { get; set; }
	public Cargo Cargo { get; set; }
	public Tire[] Tiers { get; set; }

	public override string ToString()
	{
		return Model;
	}
}
