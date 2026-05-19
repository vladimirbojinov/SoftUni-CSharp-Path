namespace _04._Product_Shop
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();

			string command = string.Empty;
			while ((command = Console.ReadLine()) != "Revision")
			{
				string[] data = command
					.Split(", ")
					.ToArray();

				string shop = data[0];
				string product = data[1];
				double price = double.Parse(data[2]);

				if (!dictionary.ContainsKey(shop))
				{
					dictionary[shop] = new Dictionary<string, double>();
				}

				dictionary[shop][product] = price;
			}

			dictionary = dictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

			foreach ((string shop, var productMap) in dictionary)
			{
				Console.WriteLine($"{shop}->");
                foreach ((string product, double price) in productMap)
				{
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
			}
		}
	}
}
