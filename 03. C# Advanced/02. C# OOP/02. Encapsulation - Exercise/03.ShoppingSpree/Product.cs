namespace _03.ShoppingSpree;

public class Product
{
	public Product(string name, double price)
	{
		if (price < 0) throw new ArgumentException("Money cannot be negative");

		Name = name;
		Price = price;
	}

	public string Name { get; }
	public double Price { get; set; }

	public override string ToString()
	{
		return $"{this.Name}";
	}
}
