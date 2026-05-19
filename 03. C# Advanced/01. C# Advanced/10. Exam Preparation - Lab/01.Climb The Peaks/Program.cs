namespace _01.Climb_The_Peaks;

internal class Program
{
	static void Main(string[] args)
	{
		List<(string name, int difficulty)> peaks = new()
		{
			("Vihren", 80),
			("Kutelo", 90),
			("Banski Suhodol", 100),
			("Polezhan", 60),
			("Kamenitza", 70)
		};

		Stack<int> portions = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
		Queue<int> stamina = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

		int concurredPeaks = 0;
		while (portions.Any() && stamina.Any())
		{
			int currentPortion = portions.Pop();
			int currentStamina = stamina.Dequeue();

			int currentStrength = currentPortion + currentStamina;

			if (peaks[concurredPeaks].difficulty <= currentStrength)
			{
				concurredPeaks++;
			}

			if (concurredPeaks == 5) break;
		}

		switch (concurredPeaks)
		{
			case 5: Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK"); break;
			case < 5: Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS"); break;
		}

		if (concurredPeaks != 0) Console.WriteLine("Conquered peaks:");
		for (int i = 0; i < concurredPeaks; i++)
		{
			Console.WriteLine(peaks[i].name);
		}
	}
}
