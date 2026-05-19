namespace DefiningClasses;

internal class StartUp
{
	static void Main(string[] args)
	{
		Dictionary<string, Trainer> trainersMap = GetTrainersData();
		TournamentResults(trainersMap);
	}

	private static void TournamentResults(Dictionary<string, Trainer> trainersMap)
	{
		Func<List<Pokemon>, string, bool> containsElement = (pokemons, element)
						=> pokemons.Any(x => x.Element == element);

		Action<List<Pokemon>> reduceHealth = (pokemons) =>
		{
			pokemons.ForEach(x => x.Health -= 10);
			pokemons.RemoveAll(x => x.Health <= 0);
		};

		string command;
		while ((command = Console.ReadLine()) != "End")
		{
			string element = command;

			foreach ((string trainerName, Trainer trainerData) in trainersMap)
			{
				if (containsElement(trainerData.Pokemons, element)) trainerData.BadgeCount++;
				else reduceHealth(trainerData.Pokemons);
			}
		}

		trainersMap = trainersMap.Values
			.OrderByDescending(x => x.BadgeCount)
			.ToDictionary(x => x.Name, x => x);

        Console.WriteLine(string.Join("\n", trainersMap.Values));
    }

	private static Dictionary<string, Trainer> GetTrainersData()
	{
		Dictionary<string, Trainer> trainersMap = new Dictionary<string, Trainer>();

		string command;
		while ((command = Console.ReadLine()) != "Tournament")
		{
			string[] data = command
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			string trainerName = data[0];
			string pokemonName = data[1];
			string pokemonElement = data[2];
			int pokemonHealth = int.Parse(data[3]);

			if (!trainersMap.ContainsKey(trainerName))
			{
				Trainer trainer = new Trainer(trainerName);
				trainersMap[trainerName] = trainer;
			}

			Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
			trainersMap[trainerName].Pokemons.Add(pokemon);
		}

		return trainersMap;
	}
}
