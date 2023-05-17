namespace _02._Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string pass = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == pass)
                {
                    Console.WriteLine($"Welcome {name}!");
                    break;
                }
            }
        }
    }
}