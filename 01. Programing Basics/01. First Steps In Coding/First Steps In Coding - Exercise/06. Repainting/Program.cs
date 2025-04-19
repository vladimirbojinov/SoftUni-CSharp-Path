namespace _06._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            double nylon = double.Parse(Console.ReadLine()) + 2;
            double paint = double.Parse(Console.ReadLine());
            //bonus
            double paintWithBonus = paint + (paint * 0.1);

            double detorgent = double.Parse(Console.ReadLine());
            int workHours = int.Parse(Console.ReadLine());
            //calculations
            double nylonPrice = nylon * 1.50;
            double paintPrice = paintWithBonus * 14.50;
            double detorgentPrice = detorgent * 5.0;
            double priceOfAll = nylonPrice + paintPrice + detorgentPrice + 0.40;
            double priceForWorker = (priceOfAll * 0.3) * workHours;
            double finallPrice = priceOfAll + priceForWorker;
            //output
            Console.WriteLine(finallPrice);
        }
    }
}