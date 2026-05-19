namespace _04.PizzaCalories;

internal class Dough
{
	private static Dictionary<string, double> FlourTypeCalories = new()
	{
		["white"] = 1.5,
		["wholegrain"] = 1.0
	};

	private static Dictionary<string, double> BakingTechniqueCalories = new()
	{
		["crispy"] = 0.9,
		["chewy"] = 1.1,
		["homemade"] = 1.0
	};

	private const int BaseCalories = 2;

	public Dough(string flourType, string bakingTechnique, double grams)
	{
		if (!FlourTypeCalories.ContainsKey(flourType.ToLower())) throw new ArgumentException("Invalid type of dough.");
		if (!BakingTechniqueCalories.ContainsKey(bakingTechnique.ToLower())) throw new ArgumentException("Invalid type of dough.");
		if (grams < 1 || grams > 200) throw new ArgumentException("Dough weight should be in the range [1..200].");

		this.DoughType = flourType.ToLower();
		this.BakingTechnique = bakingTechnique.ToLower();
		this.Grams = grams;
	}

	public double Grams { get; }
	public string DoughType { get; }
	public string BakingTechnique { get; }
	public double TotalCalories => CalculateCalories();

	private double CalculateCalories()
		=> (BaseCalories * this.Grams) * FlourTypeCalories[this.DoughType] * BakingTechniqueCalories[this.BakingTechnique];
	
}
