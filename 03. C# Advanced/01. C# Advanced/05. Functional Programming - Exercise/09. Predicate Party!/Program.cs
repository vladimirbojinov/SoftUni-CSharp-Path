namespace _09._Predicate_Party_
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> guestsList = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToList();

			string command;
			while ((command = Console.ReadLine()) != "Party!")
			{
				string[] array = command
					.Split(" ", StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				string action = array[0];
				string filter = array[1];
				string parameter = array[2];

				ApplyFilter(action, filter, parameter, guestsList);
			}

			if (guestsList.Count == 0)
			{
                Console.WriteLine("Nobody is going to the party!");
            }
			else
			{
                Console.WriteLine($"{string.Join(", ", guestsList)} are going to the party!");
            }
        }

		private static void ApplyFilter(string action, string filter, string parameter, List<string> guestsList)
		{
			List<string> filterByCriteria = new List<string>();

			Predicate<string> startWithParameter = name => name.StartsWith(parameter);
			Predicate<string> endWithParameter = name => name.EndsWith(parameter);
			Predicate<string> matchingLength = name => name.Length.ToString() == parameter;

			switch (filter)
			{
				case "StartsWith": filterByCriteria = guestsList.FindAll(name => startWithParameter(name)); break;
				case "EndsWith": filterByCriteria = guestsList.FindAll(name => endWithParameter(name)); break;
				case "Length": filterByCriteria = guestsList.FindAll(name => matchingLength(name)); break;
			}

			foreach (string name in filterByCriteria)
			{
				if (guestsList.Contains(name))
				{
					switch (action)
					{
						case "Remove": guestsList.Remove(name); break;
						case "Double": guestsList.Insert(0, name); break;
					}
				}
			}
		}
	}
}
