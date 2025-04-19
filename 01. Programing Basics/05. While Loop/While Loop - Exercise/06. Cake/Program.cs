namespace _06._Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());

            int cakeSlices = width * hight;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "STOP")
                {
                    Console.WriteLine($"{cakeSlices} pieces are left.");
                    break;
                }
                else
                {
                    cakeSlices -= int.Parse(command);
                    if (cakeSlices < 0)
                    {
                        Console.WriteLine($"No more cake left! You need {Math.Abs(cakeSlices)} pieces more.");
                        break;
                    }
                }
            }
        }
    }
}