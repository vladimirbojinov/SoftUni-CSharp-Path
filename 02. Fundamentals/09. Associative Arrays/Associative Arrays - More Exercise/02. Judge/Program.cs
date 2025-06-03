namespace _02._Judge
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<Participant> participants = new List<Participant>();
			List<string> contests = new List<string>();

			string command;
			while ((command = Console.ReadLine()) != "no more time")
			{
				string[] arguments = command.Split(" -> ");
				string username = arguments[0];
				string contest = arguments[1];
				int points = int.Parse(arguments[2]);

				if (!contests.Contains(contest))
				{
					contests.Add(contest);
				}

				Participant matchedParticipant = participants.FirstOrDefault(p => p.Name == username);
				if (matchedParticipant == null)
				{
					Participant participant = new Participant(username);
					participant.AddContest(contest, points);
					participants.Add(participant);
				}
				else
				{
					matchedParticipant.AddContest(contest, points);
				}
			}

			List<Participant> orderedParticipants = new List<Participant>();
			foreach (string contest in contests)
			{
				orderedParticipants = participants
					.Where(p => p.Contests.ContainsKey(contest))
					.OrderByDescending(p => p.Contests[contest])
					.ThenBy(p => p.Name)
					.ToList();

				Console.WriteLine($"{contest}: {orderedParticipants.Count} participants");
				int counter = 1;
				foreach (Participant participant in orderedParticipants)
				{
					Console.WriteLine($"{counter++}. {participant.Name} <::> {participant.Contests[contest]}");
				}
			}

			orderedParticipants = participants
				.OrderByDescending(p => p.Contests.Values.Sum())
				.ThenBy(p => p.Name)
				.ToList();

			Console.WriteLine("Individual standings:");
			for (int i = 0; i < orderedParticipants.Count; i++)
			{
				Console.WriteLine($"{i +1}. {orderedParticipants[i]}");
			}
		}
	}
	class Participant
	{
		public Participant(string name)
		{
			Name = name;
			Contests = new Dictionary<string, int>();
		}

		public string Name { get; set; }
		public Dictionary<string, int> Contests { get; set; }

		public void AddContest(string contest, int points)
		{
			if (Contests.ContainsKey(contest))
			{
				UpdatePoints(contest, points);
				return;
			}

			Contests.Add(contest, points);
		}

		public void UpdatePoints(string contest, int points)
		{
			if (Contests[contest] < points)
			{
				Contests[contest] = points;
			}
		}

		public override string ToString()
		{
			return $"{Name} -> {Contests.Values.Sum()}";
		}
	}
}