namespace _01._Oscars_ceremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double statuePrice = rent * 0.70;
            double cateringPrice = statuePrice * 0.85;
            double sound = cateringPrice / 2;
            double totalSum = rent + statuePrice + cateringPrice + sound;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}