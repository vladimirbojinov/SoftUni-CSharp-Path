namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            NumberToPower(num, power);
        }

        static void NumberToPower(double num, int power)
        {
            Console.WriteLine(Math.Pow(num, power));
        }
    }
}