namespace _06._Max_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int max = int.MinValue;
            int value = 0;

            while (input != "Stop")
            {
                value = int.Parse(input);

                if (value > max)
                {
                    max = value;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(max);
        }
    }
}