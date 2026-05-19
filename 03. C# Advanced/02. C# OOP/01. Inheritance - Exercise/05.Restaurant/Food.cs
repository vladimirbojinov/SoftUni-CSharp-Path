namespace Restaurant;

public class Food : Product
{
	private readonly double grams;

	public Food(string name, decimal price, double grams) : base(name, price)
	{
		this.grams = grams;
	}

	public double Gram => this.grams;
}
