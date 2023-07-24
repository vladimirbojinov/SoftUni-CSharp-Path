using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Furniture
    {
        public Furniture(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Total = price * quantity;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Furniture> furnitureList = new List<Furniture>();

            string pattern = @">>(?<name>[A-Z][A-Za-z]+)<<(?<price>\d+\.\d+|\d+)!(?<quantity>\d+)";
            Regex regex = new Regex(pattern);

            string command;
            while ((command = Console.ReadLine()) != "Purchase")
            {
                Match match = regex.Match(command);
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    decimal price = decimal.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);

                    Furniture furniture = new Furniture(name, price, quantity);
                    furnitureList.Add(furniture);
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (Furniture furniture in furnitureList)
            {
                Console.WriteLine(furniture.Name);
            }

            decimal total = 0;
            foreach (Furniture furniture in furnitureList)
            {
                total += furniture.Total;
            }

            Console.WriteLine($"Total money spend: {total:F2}");
        }
    }
}