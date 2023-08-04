using System.Text.RegularExpressions;

namespace Problem_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loops = int.Parse(Console.ReadLine());

            string pattern = @"^([$,%])(?<message>[A-Z][a-z]+)\1: \[(?<number1>\d+)\]\|\[(?<number2>\d+)\]\|\[(?<number3>\d+)\]\|$";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < loops; i++)
            {
                string input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    string message = match.Groups["message"].Value;
                    int number1 = int.Parse(match.Groups["number1"].Value);
                    int number2 = int.Parse(match.Groups["number2"].Value);
                    int number3 = int.Parse(match.Groups["number3"].Value);

                    if (number1 >= 0 && number1 <= 127 && number2 >= 0 && number2 <= 127 && number3 >= 0 && number3 <= 127)
                    {
                        Console.WriteLine($"{message}: {(char)number1}{(char)number2}{(char)number3}");
                    }
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}