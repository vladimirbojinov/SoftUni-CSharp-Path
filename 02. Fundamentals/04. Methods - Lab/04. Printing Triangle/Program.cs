namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                PrintLine(i);
                Console.WriteLine();
            }

            for (int i = n; i >= 1; i--)
            {
                PrintLine(i - 1);
                Console.WriteLine();
            }
        }


        static void PrintLine(int n)
        {
            for (int j = 1; j <= n; j++)
            {
                Console.Write(j + " ");
            }
        }
    }
}