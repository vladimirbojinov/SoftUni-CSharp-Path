namespace _05._Shopping_Spree
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Person> people = GetPeople();
			List<Product> products = GetProducts();

			string command;
			while ((command = Console.ReadLine()) != "END")
			{
				string[] input = command.Split();

				string searchedPerson = input[0];
				string searchedProduct = input[1];

				Person person = people.FirstOrDefault(p => p.Name == searchedPerson);
				Product product = products.FirstOrDefault(p => p.Name == searchedProduct);

				if (person.Money - product.Price >= 0)
				{
					person.ProductsBag.Add(product);
					person.Money -= product.Price;
					Console.WriteLine($"{person.Name} bought {product.Name}");
				}
				else
				{
					Console.WriteLine($"{person.Name} can't afford {product.Name}");
				}
			}

			Console.WriteLine(string.Join("\n", people));
		}

		private static List<Product> GetProducts()
		{
			List<Product> products = new List<Product>();

			string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
			foreach (string inputItem in input)
			{
				string[] data = inputItem.Split('=');
				string name = data[0];
				double cost = double.Parse(data[1]);

				Product product = new Product(name, cost);
				products.Add(product);
			}

			return products;
		}

		private static List<Person> GetPeople()
		{
			List<Person> people = new List<Person>();

			string[] input = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
			foreach (string inputItem in input)
			{
				string[] data = inputItem.Split('=');
				string name = data[0];
				double money = double.Parse(data[1]);

				Person person = new Person(name, money);
				people.Add(person);
			}

			return people;
		}
	}
	
	public class Person
	{
		public Person(string name, double money)
		{
			Name = name;
			Money = money;
			ProductsBag = new List<Product>();
		}

		public string Name { get; set; }
		public double Money { get; set; }
		public List<Product> ProductsBag { get; set; }

		public override string ToString()
		{
			string boughtProducts = string.Join(", ", ProductsBag);

			if (boughtProducts.Length == 0)
			{
				boughtProducts = "Nothing bought";
			}

			return $"{Name} - {boughtProducts}";
		}
	}

	public class Product
	{
		public Product(string name, double price)
		{
			Name = name;
			Price = price;
		}

		public string Name { get; set; }
		public double Price { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
