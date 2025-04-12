namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());

            double sum = 0;
            for (int i = 1; i <= orders; i++)
            {
				double capsulePrice = double.Parse(Console.ReadLine());
				int days = int.Parse(Console.ReadLine());
				int capsulesCount = int.Parse(Console.ReadLine());

				double price = (days * capsulesCount) * capsulePrice;

                sum += price;
                Console.WriteLine($"The price for the coffee is: ${price:F2}");
            }

            Console.WriteLine($"Total: ${sum:F2}");
        }
    }
}