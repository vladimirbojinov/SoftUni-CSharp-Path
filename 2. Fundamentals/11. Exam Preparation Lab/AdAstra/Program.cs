using System.Text.RegularExpressions;

namespace AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|\|)(?<itemName>[A-Za-z\s]+)\1(?<date>\d{2}/\d{2}/\d{2})\1(?<calories>\d+)\1";
            string text = Console.ReadLine();

            int caloriesPerDay = 2000;

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            int totalCalories = 0;

            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["calories"].Value);
            }

            int totalDays = totalCalories / caloriesPerDay;
            Console.WriteLine($"You have food to last you for: {totalDays} days!");
            foreach (Match match in matches)
            {
                string itemName = match.Groups["itemName"].Value;
                string date = match.Groups["date"].Value;
                string calories = match.Groups["calories"].Value;

                Console.WriteLine($"Item: {itemName}, Best before: {date}, Nutrition: {calories}");
            }
        }
    }
}