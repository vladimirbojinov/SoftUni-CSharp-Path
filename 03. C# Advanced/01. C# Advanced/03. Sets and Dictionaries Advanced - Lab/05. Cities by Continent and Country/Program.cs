namespace _05._Cities_by_Continent_and_Country
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());
			Dictionary<string, Dictionary<string, List<string>>> dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

			for (int i = 0; i < count; i++)
			{
				string[] data = Console.ReadLine()
					.Split()
					.ToArray();

				string continent = data[0];
				string country = data[1];
				string city = data[2];

				if (!dictionary.ContainsKey(continent))
				{
					dictionary[continent] = new Dictionary<string, List<string>>();
				}

				if (!dictionary[continent].ContainsKey(country))
				{
					dictionary[continent][country] = new List<string>();
				}

				dictionary[continent][country].Add(city);
			}

			foreach ((string continent, var countryMap) in dictionary)
			{
                Console.WriteLine($"{continent}: ");
				foreach ((string country, var cities) in countryMap)
				{
					Console.Write($"	{country} -> ");
					Console.WriteLine(string.Join(", ", cities));
                }
            }
		}
	}
}
