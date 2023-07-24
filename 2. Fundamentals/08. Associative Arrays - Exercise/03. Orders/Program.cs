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
                string product = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);
                

                Product productData = new Product(product, price, quantity);
                if (!productDictionary.ContainsKey(product))
                {
                    productDictionary.Add(product, productData);
                }
                else
                {
                    productDictionary[product].Update(price, quantity);
                }
            }

            Console.WriteLine(string.Join("\n", productDictionary.Values));
        }
    }

    class Product
    {
        public Product(string productName, double price, int quantity)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            TotalPrice = Price * Quantity;
        }

        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public double Update(double price, int quantity)
        {
            Price = price;
            Quantity += quantity;
            TotalPrice = Price * Quantity;
            return TotalPrice;
        }

        public override string ToString()
        {
            return $"{ProductName} -> {TotalPrice:F2}";
        }
    }
}