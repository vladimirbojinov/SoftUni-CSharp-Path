using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"\+359([ -])2\1\d{3}\1\d{4}";
            string input = Console.ReadLine();

            Regex regex = new Regex(patern);
            MatchCollection matches = regex.Matches(input);

            string print = string.Join(", ", matches);
            Console.WriteLine(print);
        }
    }
}