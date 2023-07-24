using System.ComponentModel;

namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWords = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> synonymsDict = new Dictionary<string, List<string>>();
            for (int i = 0; i < numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonyms = Console.ReadLine();

                if (!synonymsDict.ContainsKey(word))
                {
                    synonymsDict.Add(word, new List<string>());
                }

                synonymsDict[word].Add(synonyms);
            }

            foreach (var kvp in synonymsDict)
            {
                Console.Write(kvp.Key + " - ");
                Console.Write(string.Join(", ", kvp.Value));
                Console.WriteLine();
            }
        }
    }
}