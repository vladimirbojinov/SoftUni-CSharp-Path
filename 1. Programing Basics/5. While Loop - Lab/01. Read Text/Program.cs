namespace _01._Read_Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string words = Console.ReadLine();

                if (words == "Stop")
                {
                    break;
                }

                Console.WriteLine(words);
            }
        }
    }
}