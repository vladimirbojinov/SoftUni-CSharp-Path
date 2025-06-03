namespace _05._Dragon_Army
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int dragonCount = int.Parse(Console.ReadLine());
			List<Dragon> dragons = new List<Dragon>();

			for (int i = 0; i < dragonCount; i++)
			{
				string[] input = Console.ReadLine().Split();
				AddDragon(input, dragons);
			}

			Dictionary<string, List<Dragon>> dragonsByType = new Dictionary<string, List<Dragon>>();
			foreach (Dragon dragon in dragons)
			{
				if (!dragonsByType.ContainsKey(dragon.Type))
				{
					dragonsByType.Add(dragon.Type, new List<Dragon>());
				}

				dragonsByType[dragon.Type].Add(dragon);
			}

			foreach (List<Dragon> dragonsList in dragonsByType.Values)
			{
				double averageDamage = dragonsList.Average(d => d.Damage);
				double averageHealth = dragonsList.Average(d => d.Health);
				double averageArmor = dragonsList.Average(d => d.Armor);

				string type = dragonsList.FirstOrDefault().Type;
				List<Dragon> dragonsByName = dragonsList.OrderBy(d => d.Name).ToList();

				Console.WriteLine($"{type}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");
				Console.WriteLine(string.Join("\n", dragonsByName));
			}
		}

		private static void AddDragon(string[] input, List<Dragon> dragons)
		{
			string type = input[0];
			string name = input[1];

			int damage;
			if (input[2] == "null")
			{
				damage = 45;
			}
			else
			{
				damage = int.Parse(input[2]);
			}

			int health;
			if (input[3] == "null")
			{
				health = 250;
			}
			else
			{
				health = int.Parse(input[3]);
			}

			int armor;
			if (input[4] == "null")
			{
				armor = 10;
			}
			else
			{
				armor = int.Parse(input[4]);
			}

			Dragon matchedDragon = dragons.FirstOrDefault(d => d.Type == type && d.Name == name);
			if (matchedDragon == null)
			{
				Dragon dragon = new Dragon(type, name, damage, health, armor);
				dragons.Add(dragon);
			}
			else
			{
				matchedDragon.OverrideStats(damage, health, armor);
			}
		}
	}

	public class Dragon
	{
		public Dragon(string type, string name, int damage, int health, int armor)
		{
			Type = type;
			Name = name;
			Damage = damage;
			Health = health;
			Armor = armor;
		}

		public string Type { get; set; }
		public string Name { get; set; }
		public int Damage { get; set; }
		public int Health { get; set; }
		public int Armor { get; set; }

		public void OverrideStats(int damage, int health, int armor)
		{
			Damage = damage;
			Health = health;
			Armor = armor;
		}

		public override string ToString()
		{
			return $"-{Name} -> damage: {Damage}, health: {Health}, armor: {Armor}";
		}
	}
}