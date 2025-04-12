namespace _02._Bracelet_Stand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pocketMoney = double.Parse(Console.ReadLine());
            double pocketMoneyEarned = double.Parse(Console.ReadLine());
            double expences = double.Parse(Console.ReadLine());
            double pressentPrice = double.Parse(Console.ReadLine());

            double savedMoney = 5 * pocketMoney;
            double earnedMoney = 5 * pocketMoneyEarned;
            double totalSaved = (savedMoney + earnedMoney) - expences;

            if (totalSaved >= pressentPrice)
            {
                Console.WriteLine($"Profit: {totalSaved:f2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {pressentPrice - totalSaved:f2} BGN.");
            }
        }
    }
}