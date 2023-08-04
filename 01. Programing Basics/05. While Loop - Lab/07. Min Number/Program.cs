namespace _07._Min_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int min = int.MaxValue;
            int value = 0;

            while (input != "Stop")
            {
                value = int.Parse(input);

                if (value < min)
                {
                    min = value;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(min);
        }
    }
}