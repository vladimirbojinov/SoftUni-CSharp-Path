namespace _02._Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine()
                .Split()
                .Select(x => x.ToLower())
                .ToArray();

            Dictionary<string, int> wordsEncounter = new Dictionary<string, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!wordsEncounter.ContainsKey(text[i]))
                {
                    wordsEncounter.Add(text[i], 0);
                }

                wordsEncounter[text[i]]++;
            }

            foreach (var word in wordsEncounter)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write(word.Key + " ");
                }
            }
        }
    }
}