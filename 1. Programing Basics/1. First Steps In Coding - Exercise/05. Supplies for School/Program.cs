namespace _05._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            double pensCount = double.Parse(Console.ReadLine()) * 5.80;
            double markersCount = double.Parse(Console.ReadLine()) * 7.20;
            double detergentCount = double.Parse(Console.ReadLine()) * 1.20;
            double discountCount = double.Parse(Console.ReadLine()) / 100;
            //calculations
            double sum = pensCount + markersCount + detergentCount;
            double sumDisc = sum - (sum * discountCount);
            //output
            Console.WriteLine(sumDisc);
        }
    }
}