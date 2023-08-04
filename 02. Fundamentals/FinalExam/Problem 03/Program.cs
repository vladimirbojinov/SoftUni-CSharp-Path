namespace Problem_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Word> wordsDictionary = new Dictionary<string, Word>();

            string[] wordAndDefinitions = Console.ReadLine().Split(" | ");

            foreach (string wordAndDefinition in wordAndDefinitions)
            {
                string[] words = wordAndDefinition.Split(": ");

                if (!wordsDictionary.ContainsKey(words[0]) && words.Length > 1)
                {
                    Word word = new Word(words[0]);
                    word.AddDefenition(words[1]);
                    wordsDictionary.Add(words[0], word);
                }
                else if (words.Length > 1)
                {
                    Word isWordExisting = wordsDictionary.Values.FirstOrDefault(x => x.Name == words[0]);

                    if (isWordExisting != null)
                    {
                        isWordExisting.AddDefenition(words[1]);
                    }
                }
            }

            List<string> testWord = Console.ReadLine()
                .Split(" | ")
                .ToList();

            string command = Console.ReadLine();
            if (command == "Test")
            {
                wordsDictionary = wordsDictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                foreach (var kvp in wordsDictionary)
                {
                    string key = kvp.Key;
                    if (testWord.Contains(key))
                    {
                        Console.WriteLine($"{kvp.Key}:");
                        List<string> definitions = kvp.Value.Definitions;
                        foreach (string definition in definitions)
                        {
                            Console.WriteLine($" -{definition}");
                        }
                    }
                }

            }
            else if (command == "Hand Over")
            {
                Console.WriteLine(string.Join(" ", wordsDictionary.Keys));
            }
        }
    }

    class Word
    {
        public Word(string name)
        {
            Name = name;
            Definitions = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Definitions { get; set; }

        public void AddDefenition(string word)
        {
            Definitions.Add(word);
        }
    }
}