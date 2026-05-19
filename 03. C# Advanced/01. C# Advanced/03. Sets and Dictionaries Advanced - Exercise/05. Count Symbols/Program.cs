namespace _05._Count_Symbols
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();

			Dictionary<char, int> dictionary = new Dictionary<char, int>();

			for (int i = 0; i < text.Length; i++)
			{
				if (!dictionary.ContainsKey(text[i]))
				{
					dictionary[text[i]] = 0;
				}

				dictionary[text[i]]++;
			}

			dictionary = dictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x=> x.Value);
			foreach ((char symbol, int count) in dictionary)
			{
                Console.WriteLine($"{symbol}: {count} time/s");
            }
		}
	}
}
