
namespace _06._Wardrobe
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());

			Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();

			for (int i = 0; i < count; i++)
			{
				string[] clothByColor = Console.ReadLine()
					.Split(" -> ")
					.ToArray();

				string color = clothByColor[0];
				string[] clothes = clothByColor[1]
					.Split(",")
					.ToArray();

				FillDictionary(dictionary, color, clothes);
			}

			string[] searchedCloth = Console.ReadLine()
				.Split()
				.ToArray();

			string searchedColor = searchedCloth[0];
			string searchedType = searchedCloth[1];

			foreach ((string color, var clothesMap) in dictionary)
			{
				Console.WriteLine($"{color} clothes:");
                foreach ((string cloth, int clothCount) in clothesMap)
				{
                    Console.Write($"* {cloth} - {clothCount}");

					if (searchedColor == color && searchedType == cloth)
					{
                        Console.Write(" (found!)");
                    }

					Console.WriteLine();
                }
            }
		}

		private static void FillDictionary(Dictionary<string, Dictionary<string, int>> dictionary, string color, string[] clothes)
		{
			for (int i = 0; i < clothes.Length; i++)
			{
				string currentCloth = clothes[i];

				if (!dictionary.ContainsKey(color))
				{
					dictionary[color] = new Dictionary<string, int>();
				}

				if (!dictionary[color].ContainsKey(currentCloth))
				{
					dictionary[color][currentCloth] = 0;
				}

				dictionary[color][currentCloth]++;
			}
		}
	}
}
