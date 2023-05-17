namespace _11._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            double capsulePrice = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int capsulesCount = int.Parse(Console.ReadLine());

            double price = 0;
            double sum = 0;

            for (int i = 1; i <= orders; i++)
            {
                if (i >= 2)
                {
                    capsulePrice = double.Parse(Console.ReadLine());
                    days = int.Parse(Console.ReadLine());
                    capsulesCount = int.Parse(Console.ReadLine());
                }

                price = ((days * capsulesCount) * capsulePrice);

                sum += price;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }

            Console.WriteLine($"Total: ${sum:f2}");
        }
    }
}