
namespace _04.PizzaCalories;

internal class Pizza
{
	public Pizza(string name, Dough dough, List<Topping> toppings)
	{
		if (string.IsNullOrWhiteSpace(name) || name.Length > 15) throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
		if (toppings.Count > 10) throw new ArgumentException("Number of toppings should be in range [0..10].");

		Name = name;
		Dough = dough;
		Toppings = toppings;
	}

	public string Name { get; }
	public Dough Dough { get; }
	public List<Topping> Toppings { get; }
	public double TotalCalories => CalculateCalories();

	private double CalculateCalories()
		=> Toppings.Sum(x => x.TotalCalories) + Dough.TotalCalories;

	public override string ToString()
	{
		return $"{Name} - {TotalCalories:F2} Calories.";
	}
}
