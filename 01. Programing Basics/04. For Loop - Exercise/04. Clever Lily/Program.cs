namespace _04._Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int toyCount = 0;
            double totalMoney = 0.0;
            int money = 10;
            int brother = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    brother++;
                    totalMoney += money;
                    money += 10;
                }
                else
                {
                    toyCount++;
                }
            }

            toyPrice = toyCount * toyPrice;
            double moneySaved = (totalMoney + toyPrice) - brother;

            if (moneySaved >= washingMachine)
            {
                Console.WriteLine($"Yes! {moneySaved - washingMachine:f2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachine - moneySaved:f2}");
            }
        }
    }
}