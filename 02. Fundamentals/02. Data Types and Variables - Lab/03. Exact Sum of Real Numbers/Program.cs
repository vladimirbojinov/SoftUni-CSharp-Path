namespace _03._Exact_Sum_of_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            decimal sum = 0m;

            for (int i = 0; i < loops; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
			}

            Console.WriteLine(sum);
        }
    }
}