namespace _04._Darts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int startingPoints = 301;
            int Hit = 0;
            int Miss = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Retire")
                {
                    Console.WriteLine($"{name} retired after {Miss} unsuccessful shots.");
                    break;
                }

                string targetHit = command;
                int points = int.Parse(Console.ReadLine());

                if (targetHit == "Triple")
                {
                    points *= 3;
                }
                else if (targetHit == "Double")
                {
                    points *= 2;
                }
                
                if (points <= startingPoints)
                {
                    Hit++;
                    startingPoints -= points;
                }
                else
                {
                    Miss++;
                }

                if (startingPoints == 0)
                {
                    Console.WriteLine($"{name} won the leg with {Hit} shots.");
                    break;
                }
            }
        }
    }
}