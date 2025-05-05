namespace _05._Teamwork_Projects
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Team> teams = TeamCreation();
			MemberRecruitment(teams);

			List<string> disbandedTeams = new List<string>();
			for (int i = teams.Count - 1; i >= 0; i--)
			{
				if (teams[i].Members.Count == 0)
				{
					disbandedTeams.Add(teams[i].Name);
					teams.RemoveAt(i);
				}
			}

			List<Team> sortedTeams = teams
				.OrderByDescending(t => t.Members.Count)
				.ThenBy(t => t.Name)
				.ToList();

			Console.WriteLine(string.Join("\n", sortedTeams));
			Console.WriteLine("Teams to disband:");
			Console.WriteLine(string.Join("\n", disbandedTeams.OrderBy(t => t)));
		}

		private static void MemberRecruitment(List<Team> teams)
		{
			string command;
			while ((command = Console.ReadLine()) != "end of assignment")
			{
				string[] input = command.Split("->");

				string user = input[0];
				string teamName = input[1];

				Team team = teams.FirstOrDefault(t => t.Name == teamName);
				if (team == null)
				{
					Console.WriteLine($"Team {teamName} does not exist!");
					continue;
				}

				team = teams.FirstOrDefault(t => t.Members.Contains(user) || t.Owner == user);
				if (team != null)
				{
					Console.WriteLine($"Member {user} cannot join team {teamName}!");
					continue;
				}

				team = teams.FirstOrDefault(t => t.Name == teamName);
				team.Members.Add(user);
			}
		}

		private static List<Team> TeamCreation()
		{
			List<Team> teams = new List<Team>();

			int teamCount = int.Parse(Console.ReadLine());

			for (int i = 0; i < teamCount; i++)
			{
				string[] input = Console.ReadLine().Split('-');

				string user = input[0];
				string teamName = input[1];

				Team team = teams.FirstOrDefault(t => t.Name == teamName);
				if (team != null)
				{
					Console.WriteLine($"Team {teamName} was already created!");
					continue;
				}

				team = teams.FirstOrDefault(t => t.Owner == user);
				if (team != null)
				{
					Console.WriteLine($"{user} cannot create another team!");
					continue;
				}

				team = new Team(teamName, user);
				Console.WriteLine($"Team {teamName} has been created by {user}!");
				teams.Add(team);
			}

			return teams;
		}
	}

	public class Team
	{
		public Team(string name, string owner)
		{
			Name = name;
			Owner = owner;
			Members = new List<string>();
		}

		public string Name { get; set; }
		public string Owner { get; set; }
		public List<string> Members { get; set; }

		public override string ToString()
		{
			string result = $"{Name}\n";
			result += $"- {Owner}\n";

			foreach (string member in Members.OrderBy(m => m))
			{
				result += $"-- {member}\n";
			}

			return result.Trim();
		}
	}
}