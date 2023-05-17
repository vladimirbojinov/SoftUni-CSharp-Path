namespace _04._Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int steps = 0;

            while (steps < 10_000)
            {
                string input = Console.ReadLine();

                if (input == "Going home")
                {
                    steps += int.Parse(Console.ReadLine());
                    break;
                }
                else
                {
                    steps += int.Parse(input);
                }
            }

            if (steps > 10_000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{steps - 10_000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10_000 - steps} more steps to reach goal.");
            }
        }
    }
}