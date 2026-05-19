using _03.Raiding.Heroes;

namespace _03.Raiding;

public class StartUp
{
	static void Main(string[] args)
	{
		List<BaseHero> heroes = new();
		int heroCount = int.Parse(Console.ReadLine());

		while (heroCount != heroes.Count)
		{
			string heroName = Console.ReadLine();
			string heroType = Console.ReadLine();

			BaseHero? hero = heroType switch
			{
				nameof(Druid) => new Druid(heroName),
				nameof(Paladin) => new Paladin(heroName),
				nameof(Rogue) => new Rogue(heroName),
				nameof(Warrior) => new Warrior(heroName),
				_ => null
			};

			if (hero != null) heroes.Add(hero);
			else Console.WriteLine("Invalid hero!");
		}

		FightBoss(heroes);
	}

	private static void FightBoss(List<BaseHero> heroes)
	{
		if (heroes.Any())
		{
			int bossStrength = int.Parse(Console.ReadLine());
			int heroesStrength = 0;

			foreach (BaseHero hero in heroes)
			{
				heroesStrength += hero.Power;
				Console.WriteLine(hero.CastAbility());
			}

			if (bossStrength <= heroesStrength) Console.WriteLine("Victory!");
			else Console.WriteLine("Defeat...");
		}
	}
}
