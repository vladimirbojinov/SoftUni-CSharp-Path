namespace _03._Gaming_Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float budget = float.Parse(Console.ReadLine());
            float totalSpent = 0;
            bool isOutOfMoney = false;

            string gameName = Console.ReadLine();
            while (gameName != "Game Time")
            {
                float bought = 0F;
                bool isGameValid = true;
                switch (gameName)
                {
                    case "OutFall 4": bought = 39.99F;  break;
                    case "CS: OG": bought = 15.99F; break;
                    case "Zplinter Zell": bought = 19.99F; break;
                    case "Honored 2": bought = 59.99F; break;
                    case "RoverWatch": bought = 29.99F; break;
                    case "RoverWatch Origins Edition": bought = 39.99F; break;
                    default: Console.WriteLine("Not Found");isGameValid = false; break;
                }

                if (budget - bought >= 0 && isGameValid)
                {
                    Console.WriteLine($"Bought {gameName}");
                    budget -= bought;
                    totalSpent += bought;
                }
                else if (isGameValid == false)
                {

                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }

                if (budget == 0f)
                {
                    Console.WriteLine("Out of money!");
                    isOutOfMoney = true;
                    break;
                }

                gameName = Console.ReadLine();
            }

            if (isOutOfMoney)
            {

            }
            else
            {
                Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${budget:f2}");
            }
        }
    }
}