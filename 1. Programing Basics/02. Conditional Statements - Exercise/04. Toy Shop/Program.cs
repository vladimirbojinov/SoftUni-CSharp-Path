namespace _04._Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            int puzzle = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bear = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());

            double price = (puzzle * 2.60) + (dolls * 3.00) + (bear * 4.10) + (minions * 8.20) + (truck * 2.00);
            int numberOfToys = puzzle + dolls + bear + minions + truck;

            if (numberOfToys >= 50)
            {
                price *= 0.75;
            }

            price *= 0.90;

            if (price >= vacationPrice)
            {
                Console.WriteLine($"Yes! {price - vacationPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {vacationPrice - price:f2} lv needed.");
            }
        }
    }
}