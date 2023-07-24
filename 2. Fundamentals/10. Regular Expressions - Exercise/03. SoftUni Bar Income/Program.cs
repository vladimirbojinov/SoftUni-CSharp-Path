using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalIncome = 0;

            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.]*?(?<price>\d+\.\d+|\d+)+\$";

            Regex regex = new Regex(pattern);

            string command;
            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match match = regex.Match(command);
                if (match.Success)
                {
                    string customerName = match.Groups[1].Value;
                    string product = match.Groups[2].Value;
                    int quantity = int.Parse(match.Groups[3].Value);
                    double price = double.Parse(match.Groups[4].Value);
                    double totalPrice = price * quantity;

                    totalIncome += totalPrice;

                    Console.WriteLine($"{customerName}: {product} - {totalPrice:F2}");
                }
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}