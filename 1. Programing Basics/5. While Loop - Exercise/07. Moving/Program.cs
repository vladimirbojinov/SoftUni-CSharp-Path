namespace _07._Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int leght = int.Parse(Console.ReadLine());
            int hight = int.Parse(Console.ReadLine());

            int space = width * leght * hight;
            int spaceTaken = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Done")
                {
                    Console.WriteLine($"{space - spaceTaken} Cubic meters left.");
                    break;
                }
                else
                {
                    spaceTaken += int.Parse(command);
                }
                if (space < spaceTaken)
                {
                    Console.WriteLine($"No more free space! You need {spaceTaken - space} Cubic meters more.");
                    break;
                }
            }
        }
    }
}