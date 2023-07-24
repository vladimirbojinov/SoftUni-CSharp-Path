namespace _01._USD_to_BGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            double dollars = double.Parse(Console.ReadLine());
            //calculations
            double rate = 1.79549;
            double leva = dollars * rate;
            //output
            Console.WriteLine(leva);
        }
    }
}