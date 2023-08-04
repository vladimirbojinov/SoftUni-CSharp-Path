namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());

            int passedDay = 0;
            int spendedMoney = 0;

            while (true)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                passedDay++;

                if (command == "spend")
                {
                    spendedMoney++;
                    currentMoney -= money;

                    if (currentMoney < 0)
                    {
                        currentMoney = 0;
                    }
                }

                if (command == "save")
                {
                    spendedMoney = 0;
                    currentMoney += money;
                }

                if (currentMoney >= neededMoney)
                {
                    Console.WriteLine($"You saved the money for {passedDay} days.");
                    break;
                }

                if (spendedMoney == 5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine(passedDay);
                    break;
                }
            }
        }
    }
}