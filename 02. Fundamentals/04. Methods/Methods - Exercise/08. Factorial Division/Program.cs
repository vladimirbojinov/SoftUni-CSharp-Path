namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n1 = int.Parse(Console.ReadLine());
            double n2 = int.Parse(Console.ReadLine());

            n1 = FactorialOfN1(n1);
            n2 = FactorialOfN2(n2);

            double result = (double)n1 / n2;
            Console.WriteLine($"{result:F2}");
        }

        static double FactorialOfN2(double n2)
        {
            double factorial = 1;
            for (int j = 1; j <= n2; j++)
            {
                factorial *= j;
            }
            return factorial;
        }

        static double FactorialOfN1(double n1)
        {
            double factorial = 1;
            for (int i = 1; i <= n1; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}