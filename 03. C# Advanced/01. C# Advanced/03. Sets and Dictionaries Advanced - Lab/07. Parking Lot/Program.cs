namespace _07._Parking_Lot
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HashSet<string> set = new HashSet<string>();

			string command = string.Empty;
			while ((command = Console.ReadLine()) != "END")
			{
				string[] data = command
					.Split(", ")
					.ToArray();

				string direction = data[0];
				string carNumber = data[1];
				
				switch (direction)
				{
					case "IN": set.Add(carNumber); break;
					case "OUT": set.Remove(carNumber); break;
				}
			}

			if (set.Count == 0)
			{
                Console.WriteLine("Parking Lot is Empty");
            }
			else
			{
                Console.WriteLine(string.Join("\n", set));
            }
		}
	}
}
