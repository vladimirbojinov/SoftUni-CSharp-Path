namespace Restaurant;

public class Product
{
	private readonly string name;
	private readonly decimal price;

	public Product(string name, decimal price)
	{
		this.name = name;
		this.price = price;
	}

	public string Name => this.name;
	public decimal Price => this.price;
}
