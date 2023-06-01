namespace _06._Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = int.Parse(Console.ReadLine());
            double b = int.Parse(Console.ReadLine());

            AreaCalculation(a, b);
        }

        static void AreaCalculation(double a, double b)
        {
            Console.WriteLine(a * b);
        }
    }
}