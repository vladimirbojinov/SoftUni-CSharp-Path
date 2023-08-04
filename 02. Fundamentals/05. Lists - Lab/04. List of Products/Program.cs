namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfProducts = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < numberOfProducts; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            for (int j = 1; j <= numberOfProducts; j++)
            {
                Console.Write($"{j}.");
                Console.Write(products[j - 1]);
                Console.WriteLine();
            }
        }
    }
}