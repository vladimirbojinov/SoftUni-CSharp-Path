using System.Text.RegularExpressions;

namespace Problem_2___Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mirroredWordList = new List<string>();

            string pattern = @"(@|#)(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1";
            string input = Console.ReadLine();

            int mirrorWordsCount = 0;

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                string firstWord = match.Groups["wordOne"].Value;
                string secondWord = match.Groups["wordTwo"].Value;

                secondWord = ReverseString(secondWord);
                if (firstWord == secondWord)
                {
                    mirrorWordsCount++;
                    secondWord = ReverseString(secondWord);
                    mirroredWordList.Add($"{firstWord} <=> {secondWord}");
                }
            }

            if (matches.Count == 0)
            {
                Console.WriteLine($"No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            if (mirroredWordList.Count == 0)
            {
                Console.WriteLine($"No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirroredWordList));
            }
        }

        static string ReverseString(string reversedWord)
        {
            string word = string.Empty;

            for (int i = reversedWord.Length - 1; i >= 0; i--)
            {
                word += reversedWord[i].ToString();
            }

            return word;
        }
    }
}