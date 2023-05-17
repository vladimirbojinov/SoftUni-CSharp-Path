namespace _06._Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double StartingPoint = double.Parse(Console.ReadLine());
            int votersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < votersCount; i++)
            {
                string voterName = Console.ReadLine();
                double pointsFromVoting = double.Parse(Console.ReadLine());
                double AfterVoting = voterName.Length * pointsFromVoting / 2;

                StartingPoint += AfterVoting;
                if (StartingPoint > 1250.5)
                {
                    break;
                }
            }

            if (StartingPoint > 1250.5)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {StartingPoint:f1}!");
            }
            else
            {
                Console.WriteLine($"Sorry, {actorName} you need {1250.5 - StartingPoint:f1} more!");
            }
        }
    }
}