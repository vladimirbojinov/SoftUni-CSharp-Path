namespace _08._Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int priceForYear = int.Parse(Console.ReadLine());
            //calculations
            double priceForShoes = priceForYear - (priceForYear * 0.4);
            double priceForOutfit = priceForShoes - (priceForShoes * 0.2);
            double priceForBall = priceForOutfit / 4;
            double priceForAcsesories = priceForBall / 5;

            double priceForEquipment = priceForYear + priceForShoes + priceForOutfit + priceForBall + priceForAcsesories;
            //output
            Console.WriteLine(priceForEquipment);
        }
    }
}