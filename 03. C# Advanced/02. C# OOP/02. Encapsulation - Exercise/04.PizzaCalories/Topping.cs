
namespace _04.PizzaCalories;

public class Topping
{
	private static Dictionary<string, double> ToppingCalories = new()
	{
		["meat"] = 1.2,
		["veggies"] = 0.8,
		["cheese"] = 1.1,
		["sauce"] = 0.9
	};

	public Topping(string name, double grams)
	{
		if (!ToppingCalories.ContainsKey(name.ToLower())) throw new ArgumentException($"Cannot place {name} on top of your pizza.");
		if (grams < 1 || grams > 50) throw new ArgumentException($"{name} weight should be in the range [1..50].");

		Name = name.ToLower();
		Grams = grams;
	}

	private const int BaseCalories = 2;

	public double Grams { get; }
	public string Name { get; }
	public double TotalCalories => CalculateCalories();

	private double CalculateCalories()
		=> (BaseCalories * Grams) * ToppingCalories[Name];
}
