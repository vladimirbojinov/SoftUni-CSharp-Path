namespace _08._Pet_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());
            //calculations
            double dogFoodPrice = dogFood * 2.50;
            double catFoodPrice = catFood * 4;
            double total = catFoodPrice + dogFoodPrice;
            //output
            Console.WriteLine($"{total} lv.");
        }
    }
}