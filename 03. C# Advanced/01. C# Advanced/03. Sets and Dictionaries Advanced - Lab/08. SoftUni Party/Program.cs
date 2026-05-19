namespace _08._SoftUni_Party
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> set = new HashSet<string>();

			FillReservationSet(set);
			CheckReceivedReservations(set);

            Console.WriteLine(set.Count);
			set = set
				.OrderBy(x => char.IsLetter(x[0]))
				.ThenBy(x => char.IsDigit(x[0]))
				.ToHashSet();

             Console.WriteLine(string.Join("\n", set));
        }

		private static void CheckReceivedReservations(HashSet<string> set)
		{
			string command = string.Empty;
			while ((command = Console.ReadLine()) != "END")
			{
				string reservationCode = command;

				if (set.Contains(reservationCode))
				{
					set.Remove(reservationCode);
				}
			}
		}

		private static void FillReservationSet(HashSet<string> set)
		{
			string command = string.Empty;
			while ((command = Console.ReadLine()) != "PARTY")
			{
				string reservationCode = command;

				if (reservationCode.Length == 8)
				{
					set.Add(reservationCode);
				}
			}
		}
	}
}
