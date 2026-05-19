namespace Restaurant;

public class Dessert : Food
{
	private readonly double calories;

	public Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
	{
		this.calories = calories;
	}

	public double Calories => this.calories;
}
