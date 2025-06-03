using System.Text;

namespace _03._MOBA_Challenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

			string command;
			while ((command = Console.ReadLine()) != "Season end")
			{
				string[] input = command.Split(" -> ");

				if (input.Length == 3)
				{
					AddPlayer(players, input);
				}
				else
				{
					input = command.Split(" vs ");
					Player playerA = players.FirstOrDefault(p => p.Name == input[0]);
					Player playerB = players.FirstOrDefault(p => p.Name == input[1]);

					if (playerA == null || playerB == null)
					{
						continue;
					}

					PlayerFight(playerA, playerB, players);
				}
			}

			List<Player> orderedPlayers = players
				.OrderByDescending(p => p.Positions.Values.Sum())
				.ThenBy(p => p.Name)
				.ToList();

			Console.WriteLine(string.Join("\n", orderedPlayers));
        }

		private static void PlayerFight(Player playerA, Player playerB, List<Player> players)
		{
			List<string> playerAPositions = playerA.Positions.Keys.ToList();
			List<string> playerBPositions = playerB.Positions.Keys.ToList();

			bool hasCommonPosition = false;
			string commonPosition = string.Empty;
			foreach (string position in playerAPositions)
			{
				if (playerBPositions.Contains(position))
				{
					hasCommonPosition = true;
					commonPosition = position;
					break;
				}
			}

			int playerATotalSkill = playerA.Positions.Values.Sum();
			int playerBTotalSkill = playerB.Positions.Values.Sum();

			if (hasCommonPosition)
			{
				if (playerATotalSkill > playerBTotalSkill)
				{
					players.Remove(playerB);
				}
				else if (playerATotalSkill < playerBTotalSkill)
				{
					players.Remove(playerA);
				}
			}
		}

		private static void AddPlayer(List<Player> players, string[] input)
		{
			string name = input[0];
			string position = input[1];
			int skill = int.Parse(input[2]);

			Player matchedPlayer = players.FirstOrDefault(p => p.Name == name);
			if (matchedPlayer == null)
			{
				Player player = new Player(name);
				player.AddPosition(position, skill);
				players.Add(player);
			}
			else
			{
				matchedPlayer.AddPosition(position, skill);
			}
		}
	}

    public class Player
    {
		public Player(string name)
		{
			Name = name;
			Positions = new Dictionary<string, int>();
		}

		public string Name { get; set; }
        public Dictionary<string, int> Positions { get; set; }

		public void AddPosition(string position, int skill)
		{
			if (Positions.ContainsKey(position))
			{
				UpdateSkill(position, skill);
				return;
			}

			Positions.Add(position, skill);
		}

		public void UpdateSkill(string position, int skill)
		{
			if (Positions[position] < skill)
			{
				Positions[position] = skill;
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{Name}: {Positions.Values.Sum()} skill");
			Dictionary<string, int> orderedPositions = Positions
				.OrderByDescending(p => p.Value)
				.ThenBy(p => p.Key)
				.ToDictionary(x => x.Key, y => y.Value);

			foreach (var position in orderedPositions)
			{
				sb.AppendLine($"- {position.Key} <::> {position.Value}");
			}

			return sb.ToString().Trim();
		}
	}
}