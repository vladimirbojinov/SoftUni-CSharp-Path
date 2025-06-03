using System.Text;

namespace _01._Ranking
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, string> lecturesPasswords = GetContests();
			List<User> users = GetUsers(lecturesPasswords);

			User bestUser = users.OrderByDescending(u => u.Contest.Values.Sum()).FirstOrDefault();
			int totalPoints = bestUser.Contest.Values.Sum();

			List<User> sortedUsers = users.OrderBy(u => u.Name).ToList();

			Console.WriteLine($"Best candidate is {bestUser.Name} with total {totalPoints} points.");
			Console.WriteLine("Ranking: ");
			Console.WriteLine(string.Join("\n", sortedUsers));
		}

		private static List<User> GetUsers(Dictionary<string, string> lecturesPasswords)
		{
			List<User> users = new List<User>();

			string command;
			while ((command = Console.ReadLine()) != "end of submissions")
			{
				string[] arguments = command.Split("=>");
				string contest = arguments[0];
				string password = arguments[1];
				string username = arguments[2];
				int points = int.Parse(arguments[3]);

				User matchedUser = users.FirstOrDefault(u => u.Name == username);
				bool isPasswordCorrect = PasswordVerifier(lecturesPasswords, contest, password);

				if (matchedUser == null && isPasswordCorrect)
				{
					User user = new User(username);
					user.AddContest(contest, points);
					users.Add(user);
				}
				else if (matchedUser != null)
				{
					matchedUser.AddContest(contest, points);
				}
			}

			return users;
		}

		private static Dictionary<string, string> GetContests()
		{
			Dictionary<string, string> lecturesPasswords = new Dictionary<string, string>();

			string command;
			while ((command = Console.ReadLine()) != "end of contests")
			{
				string[] arguments = command.Split(":");
				string contest = arguments[0];
				string password = arguments[1];

				lecturesPasswords.Add(contest, password);
			}

			return lecturesPasswords;
		}

		private static bool PasswordVerifier(Dictionary<string, string> lecturesPasswords, string contest, string password)
		{
			if (!lecturesPasswords.ContainsKey(contest))
			{
				return false;
			}

			return lecturesPasswords[contest] == password;
		}
	}

	public class User
	{
		public User(string name)
		{
			Name = name;
			Contest = new Dictionary<string, int>();
		}

		public string Name { get; set; }
		public Dictionary<string, int> Contest { get; set; }

		public void AddContest(string contest, int points)
		{
			if (Contest.ContainsKey(contest))
			{
				UpdatePoints(contest, points);
				return;
			}

			Contest[contest] = points;
		}

		public void UpdatePoints(string contest, int points)
		{
			if (Contest[contest] < points)
			{
				Contest[contest] = points;
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(Name);

			Dictionary<string, int> orderedLectures = Contest
				.OrderByDescending(l => l.Value)
				.ToDictionary(x => x.Key, y => y.Value);
			foreach (var lecture in orderedLectures)
			{
				sb.AppendLine($"#  {lecture.Key} -> {lecture.Value}");
			}

			return sb.ToString().Trim();
		}
	}
}
