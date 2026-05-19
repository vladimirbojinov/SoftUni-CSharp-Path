namespace DefiningClasses;

public class Car
{
	private string model;
	private Engine engine;
	private int weight;
	private string color;

	public Car(string model, Engine engine, int? weight, string? color)
	{
		Model = model;
		Engine = engine;
		Weight = weight;
		Color = color;
	}

	public string Model { get; set; }
	public Engine Engine { get; set; }
	public int? Weight { get; set; }
	public string? Color { get; set; }

	public override string ToString()
	{
		string? weightValue = IsNull(Weight.ToString());
		string? colorValue = IsNull(Color);
		string? displacementValue = IsNull(Engine.Displacement.ToString());
		string? efficiencyValue = IsNull(Engine.Efficiency);

		return $"{Model}:\n {Engine.Model}:\n  Power: {Engine.Power}\n  Displacement: {displacementValue}\n  Efficiency: {efficiencyValue}\nWeight: {weightValue}\nColor: {colorValue}";
	}

	private string? IsNull(string value)
	{
		if (value == null || value == "")
		{
			return "n/a";
		}

		return value;
	}
}
