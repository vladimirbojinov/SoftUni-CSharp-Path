namespace _03.ShoppingSpree;

public class Person
{
	private double money;
	private List<Product> productBag;

	public Person(string name, double money)
	{
		if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty");

		this.productBag = new List<Product>();
		this.ProductBag = this.productBag.AsReadOnly();

		this.Name = name;
		this.Money = money;
		this.ProductBag = productBag;
	}

	public string Name { get; }
	public double Money
	{
		get => this.money;
		private set
		{
			if (value < 0) throw new ArgumentException("Money cannot be negative");
			this.money = value;
		}
	}
	public IReadOnlyCollection<Product> ProductBag { get; }

	public void BuyProduct(Product product)
	{
		if (product.Price > this.Money) throw new ArgumentException($"{this.Name} can't afford {product.Name}");

		this.Money -= product.Price;
		this.productBag.Add(product);
	}

	public override string ToString()
	{
		if (ProductBag.Any()) return $"{this.Name} - {string.Join(", ", ProductBag)}";

		return $"{this.Name} - Nothing bought";
	}
}
