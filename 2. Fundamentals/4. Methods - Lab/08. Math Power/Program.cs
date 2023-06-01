namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            NumberToPower(n, power);
        }

        static void NumberToPower(double n, int power)
        {
            Console.WriteLine(Math.Pow(n, power));
        }
    }
}