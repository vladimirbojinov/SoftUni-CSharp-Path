namespace _05._Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyGiven = double.Parse(Console.ReadLine());

            int coinReturn = 0;

            while (moneyGiven > 0)
            {
                if (moneyGiven >= 2.00)
                {
                    moneyGiven -= 2;
                    coinReturn++;
                }
                else if (moneyGiven >= 1.00)
                {
                    moneyGiven -= 1;
                    coinReturn++;
                }
                else if (moneyGiven >= 0.5)
                {
                    moneyGiven -= 0.5;
                    coinReturn++;
                }
                else if (moneyGiven >= 0.2)
                {
                    moneyGiven -= 0.2;
                    coinReturn++;
                }
                else if (moneyGiven >= 0.1)
                {
                    moneyGiven -= 0.1;
                    coinReturn++;
                }
                else if (moneyGiven >= 0.05)
                {
                    moneyGiven -= 0.05;
                    coinReturn++;
                }
                else if (moneyGiven >= 0.02)
                {
                    moneyGiven -= 0.02;
                    coinReturn++;
                }
                else if (moneyGiven >= 0.01)
                {
                    moneyGiven -= 0.01;
                    coinReturn++;
                }

                moneyGiven = Math.Round(moneyGiven, 2);
            }

            Console.WriteLine(coinReturn);
        }
    }
}