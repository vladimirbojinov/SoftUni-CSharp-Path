namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> productDictionary = new Dictionary<string, Product>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] input = command.Split();
                string name = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);

                if (!productDictionary.ContainsKey(name))
                {
                    Product product = new Product(name);
                    productDictionary.Add(name, product);
                }

                productDictionary[name].UpdatePrice(price);
                productDictionary[name].AddQuantity(quantity);
            }

            foreach (Product product in productDictionary.Values)
            {
				Console.WriteLine(product);
            }
        }
    }

    public class Product
    {
		public Product(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public void UpdatePrice(double newPrice)
        {
            Price = newPrice;
        }

		public void AddQuantity(int quantity)
		{
			Quantity += quantity;
		}

		public override string ToString()
		{
            double totalPrice = Price * Quantity;
			return $"{Name} -> {totalPrice:F2}";
		}
	}
}