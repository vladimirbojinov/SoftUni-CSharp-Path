namespace _04._Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                PrintLine(i);
            }

            for (int i = num; i >= 1; i--)
            {
                PrintLine(i - 1);
            }
        }


        static void PrintLine(int n)
        {
            for (int j = 1; j <= n; j++)
            {
                Console.Write(j + " ");
            }
			Console.WriteLine();
		}
    }
}