using System.Collections.Generic;

namespace _01.MedievalAlchemy;

internal class Program
{
	static void Main(string[] args)
	{
		Dictionary<string, int> potions = new()
		{
			["Brew of Immortality"] = 110,
			["Essence of Resilience"] = 100,
			["Draught of Wisdom"] = 90,
			["Potion of Agility"] = 80,
			["Elixir of Strength"] = 70
		};

		Stack<int> substances = new(Console.ReadLine()!.Split(", ").Select(int.Parse));
		Queue<int> crystals = new(Console.ReadLine()!.Split(", ").Select(int.Parse));

		int craftedPotion = 0;
		List<string> craftedPotionsName = new();
		bool shouldMultiply = false;

		while (substances.Any() && crystals.Any())
		{
			int currentSubstance = substances.Pop();
			int currentCrystalEnergy = crystals.Dequeue();

			if (shouldMultiply) currentSubstance *= 2;
			shouldMultiply = false;

			int totalEnergy = currentSubstance + currentCrystalEnergy;
			if (potions.ContainsValue(totalEnergy))
			{
				string currentPotionName = potions.Where(x => x.Value == totalEnergy).First().Key;
				craftedPotionsName.Add(currentPotionName);
				potions.Remove(currentPotionName);

				craftedPotion++;
			}
			else
			{
				int searchedEnergyLevel = potions.Where(x => x.Value <= totalEnergy).OrderByDescending(x => x.Value).First().Value;

				if (potions.ContainsValue(searchedEnergyLevel))
				{
					string currentPotionName = potions.Where(x => x.Value == searchedEnergyLevel).First().Key;
					craftedPotionsName.Add(currentPotionName);
					potions.Remove(currentPotionName);

					craftedPotion++;
					shouldMultiply = true;
				}
			}

			crystals.Enqueue(0);
			if (craftedPotion == 5) break;

			if (substances.Any())
			{
				List<int> crystalsList = crystals.Select(x => x + 5).ToList();
				crystals = new Queue<int>(crystalsList);
			}
		}

		if (craftedPotion == 5) Console.WriteLine("Success! The alchemist has forged all potions!");
		else Console.WriteLine("The alchemist failed to complete his quest.");

		if (craftedPotionsName.Any()) Console.WriteLine($"Crafted potions: {string.Join(", ", craftedPotionsName)}");
		if (substances.Any()) Console.WriteLine($"Substances: {string.Join(", ", substances)}");
		if (crystals.Any()) Console.WriteLine($"Crystals: {string.Join(", ", crystals)}");
	}
}
