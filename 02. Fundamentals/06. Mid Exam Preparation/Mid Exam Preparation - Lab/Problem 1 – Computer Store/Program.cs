namespace Problem_1___Computer_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalWithoutTax = 0;
            double tax = 0;

            string command;
            while ((command = Console.ReadLine()) != "special" && command != "regular")
            {
                double price = double.Parse(command);

                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                totalWithoutTax += price;
                tax = totalWithoutTax * 0.20;
            }

            double totalPriceWithTax = totalWithoutTax + tax;

            if (command == "special")
            {
                totalPriceWithTax *= 0.90;
            }

            if (totalPriceWithTax > 0)
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalWithoutTax:F2}$");
                Console.WriteLine($"Taxes: {tax:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalPriceWithTax:F2}$");
            }
            else
            {
                Console.WriteLine("Invalid order!");
            }
        }
    }
}