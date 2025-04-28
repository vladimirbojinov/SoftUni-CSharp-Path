namespace _05._Drum_Set
{
	internal class Program
	{
		static void Main(string[] args)
		{
			double money = double.Parse(Console.ReadLine());
			List<int> originalDrumsQuality = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			List<int> drums = new List<int>(originalDrumsQuality);

			string command;
			while ((command = Console.ReadLine()) != "Hit it again, Gabsy!")
			{
				int hitPower = int.Parse(command);

				for (int i = 0; i < drums.Count; i++)
				{
					drums[i] -= hitPower;
					if (drums[i] <= 0)
					{
						double priceToReplace = originalDrumsQuality[i] * 3;
						if (money - priceToReplace >= 0)
						{
							drums[i] = originalDrumsQuality[i];
							money -= priceToReplace;
						}
						else
						{
							originalDrumsQuality.RemoveAt(i);
							drums.RemoveAt(i);
							i--;
						}
					}
				}
			}

			Console.WriteLine(string.Join(" ", drums));
			Console.WriteLine($"Gabsy has {money:F2}lv.");
		}
	}
}
