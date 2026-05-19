namespace WordCount
{
    using System;
    using System.Collections.Generic;
	using System.Diagnostics;
	using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                string[] data = reader.ReadLine()
                    .Split()
                    .ToArray();

                for (int i = 0; i < data.Length; i++)
                {
                    string word = data[i];

                    if (!dictionary.ContainsKey(word))
                    {
                        dictionary[word] = 0;
                    }
                }
            }

			using (StreamReader reader = new StreamReader(textFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine()
                        .ToLower();

                    foreach ((string word, int count) in dictionary)
                    {
                        if (line.Contains(word))
                        {
                            dictionary[word]++;
                        }
                    }
                }

                dictionary = dictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

			using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach ((string word, int count) in dictionary)
                {
                    writer.WriteLine($"{word} - {count}");
                }
            }
        }
    }
}
