namespace _10._The_Party_Reservation_Filter_Module
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> guestList = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToList();

			Dictionary<string, string> filterMap = new Dictionary<string, string>();

			FilterAdd(filterMap);

			foreach ((string parameter, string filter) in filterMap)
			{
				FilterApply(parameter, filter, guestList);
			}

            Console.WriteLine(string.Join(" ", guestList));
        }

		private static void FilterApply(string parameter, string filter, List<string> guestList)
		{
			List<string> filterByCriteria = new List<string>();

			Predicate<string> startWithParameter = name => name.StartsWith(parameter);
			Predicate<string> endWithParameter = name => name.EndsWith(parameter);
			Predicate<string> matchingLength = name => name.Length.ToString() == parameter;
			Predicate<string> containsParameter = name => name.Contains(parameter);

			switch (filter)
			{
				case "Starts with": filterByCriteria = guestList.FindAll(name => startWithParameter(name)); break;
				case "Ends with": filterByCriteria = guestList.FindAll(name => endWithParameter(name)); break;
				case "Length": filterByCriteria = guestList.FindAll(name => matchingLength(name)); break;
				case "Contains": filterByCriteria = guestList.FindAll(name => containsParameter(name)); break;
			}

			foreach (string name in filterByCriteria)
			{
				if (guestList.Contains(name))
				{
					guestList.Remove(name);
				}
			}
		}

		private static void FilterAdd(Dictionary<string, string> filterMap)
		{
			string command;
			while ((command = Console.ReadLine()) != "Print")
			{
				string[] array = command
					.Split(";", StringSplitOptions.RemoveEmptyEntries)
					.ToArray();

				string action = array[0];
				string filter = array[1];
				string parameter = array[2];

				switch (action)
				{
					case "Add filter": if (!filterMap.ContainsKey(parameter)) filterMap[parameter] = filter; break;
					case "Remove filter": if (filterMap.ContainsKey(parameter)) filterMap.Remove(parameter); break;
				}
			}
		}
	}
}
