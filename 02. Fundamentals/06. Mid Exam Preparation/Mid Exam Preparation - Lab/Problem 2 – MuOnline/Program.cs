namespace Problem_2___MuOnline
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int health = 100;
			int bitcoins = 0;
			bool isDead = false;

			string[] rooms = Console.ReadLine()
				.Split("|")
				.ToArray();

			for (int i = 0; i < rooms.Length; i++)
			{
				string[] input = rooms[i].Split();

				switch (input[0])
				{
					case "potion": health = PotionRoom(input, health); break;
					case "chest": bitcoins = ChestRoom(input, bitcoins); break;
					default:
						isDead = MonsterRoom(input, health, isDead);
						int monsterAttack = int.Parse(input[1]);
						health -= monsterAttack;
						break;
				}

				if (isDead)
				{
					Console.WriteLine($"You died! Killed by {input[0]}.");
					Console.WriteLine($"Best room: {i + 1}");
					break;
				}
			}

			if (!isDead)
			{
				Console.WriteLine("You've made it!");
				Console.WriteLine($"Bitcoins: {bitcoins}");
				Console.WriteLine($"Health: {health}");
			}

		}

		static int PotionRoom(string[] room, int health)
		{
			int healedAmount = int.Parse(room[1]);

			if (health + healedAmount >= 100)
			{
				healedAmount = Math.Max(0, 100 - health);
			}

			health = Math.Min(health + healedAmount, 100);

			Console.WriteLine($"You healed for {healedAmount} hp.");
			Console.WriteLine($"Current health: {health} hp.");

			return health;
		}
		
		static int ChestRoom(string[] room, int bitcoins)
		{
			int foundBitcoins = int.Parse(room[1]);
			bitcoins += foundBitcoins;

			Console.WriteLine($"You found {foundBitcoins} bitcoins.");
			return bitcoins;
		}

		static bool MonsterRoom(string[] room, int health, bool isDead)
		{
			int monsterAttack = int.Parse(room[1]);
			health -= monsterAttack;

			if (health <= 0)
			{
				return isDead = true;
			}
			else
			{
				Console.WriteLine($"You slayed {room[0]}.");
				return isDead = false;
			}
		}
	}
}