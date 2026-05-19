using System.Reflection.PortableExecutable;

namespace _03.ShoppingSpree;

public class Program
{
	static void Main(string[] args)
	{
		try
		{
			List<Person> people = ReadPeopleData();
			List<Product> products = ReadProductData();

			if (people.Any() && products.Any())
			{
				ShoppingSpree(people, products);
				Console.WriteLine(string.Join("\n", people));
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}

	}

	private static void ShoppingSpree(List<Person> people, List<Product> products)
	{
		string command;
		while ((command = Console.ReadLine()) != "END")
		{
			string[] customer = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			string customerName = customer[0];
			string productName = customer[1];

			try
			{
				Person? person = people.FirstOrDefault(x => x.Name == customerName);
				Product? product = products.FirstOrDefault(x => x.Name == productName);

				if (person != null && product != null)
				{
					person.BuyProduct(product);
					Console.WriteLine($"{person.Name} bought {product.Name}");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

	private static List<Product> ReadProductData()
	{
		List<Product> products = new();

		string[] productInformation = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
		foreach (string productData in productInformation)
		{
			string[] data = productData.Split("=", StringSplitOptions.RemoveEmptyEntries);

			string name = data[0];
			int price = int.Parse(data[1]);

			Product product = new(name, price);
			products.Add(product);
		}

		return products;
	}

	private static List<Person> ReadPeopleData()
	{
		List<Person> people = new();

		string[] personInformation = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
		foreach (string personData in personInformation)
		{
			string[] data = personData.Split("=", StringSplitOptions.RemoveEmptyEntries);

			string name = data[0];
			int price = int.Parse(data[1]);
			Person person = new(name, price);
			people.Add(person);

		}

		return people;
	}
}
