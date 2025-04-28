namespace _04._List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int productCount = int.Parse(Console.ReadLine());
            List<string> products = new List<string>();

            for (int i = 0; i < productCount; i++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            for (int j = 1; j <= productCount; j++)
            {
                Console.Write($"{j}.{products[j - 1]}");
                Console.WriteLine();
            }
        }
    }
}