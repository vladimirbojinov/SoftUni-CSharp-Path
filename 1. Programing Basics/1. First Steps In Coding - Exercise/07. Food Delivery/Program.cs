namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int numberOfChickenMenu = int.Parse(Console.ReadLine());
            int numberOfFishMenu = int.Parse(Console.ReadLine());
            int numberOfVeganMenu = int.Parse(Console.ReadLine());
            //calculations
            double priceOfChickenMenu = numberOfChickenMenu * 10.35;
            double priceOfFishMenu = numberOfFishMenu * 12.40;
            double priceOfVeganMenu = numberOfVeganMenu * 8.15;
            double priceOfAll = priceOfChickenMenu + priceOfFishMenu + priceOfVeganMenu;
            double priceOfDeserts = priceOfAll * 0.2;
            double priceOfDeliverys = priceOfAll + priceOfDeserts + 2.50;
            //output
            Console.WriteLine(priceOfDeliverys);
        }
    }
}