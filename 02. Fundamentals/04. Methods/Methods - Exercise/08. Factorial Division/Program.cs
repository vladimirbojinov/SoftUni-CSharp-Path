namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            num1 = Factorial(num1);
            num2 = Factorial(num2);

            double result = num1 / num2;
            Console.WriteLine($"{result:F2}");
        }

        static double Factorial(double num)
        {
            double factorial = 1;
            for (int j = 1; j <= num; j++)
            {
                factorial *= j;
            }
            return factorial;
        }
    }
}