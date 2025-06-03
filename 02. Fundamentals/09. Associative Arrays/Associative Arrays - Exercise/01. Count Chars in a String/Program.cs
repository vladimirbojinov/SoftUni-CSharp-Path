namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> letterOccurrences = new Dictionary<char, int>();
            char[] letters = Console.ReadLine()
                .ToCharArray()
                .Where(c => c != ' ')
                .ToArray();

            foreach (char c in letters)
            {
                if (!letterOccurrences.ContainsKey(c))
                {
                    letterOccurrences.Add(c, 0);
                }

                letterOccurrences[c]++;
            }

            foreach (var letter in letterOccurrences)
            {
				Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}