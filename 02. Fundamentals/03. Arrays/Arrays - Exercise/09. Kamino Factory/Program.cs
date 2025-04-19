namespace _09._Kamino_Factory
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int dnaLength = int.Parse(Console.ReadLine());

			int[] bestDna = new int[dnaLength];
			int bestDnaIndex = -1;
			int dnaIndex = 0;
			int bestDnaStart = -1;
			int bestDnaSequence = -1;

			string input;
			while ((input = Console.ReadLine()) != "Clone them!")
			{
				int[] dna = input
					.Split('!', StringSplitOptions.RemoveEmptyEntries)
					.Select(int.Parse)
					.ToArray();

				dnaIndex++;
				int bestCurrentDnaSequence = -1;
				int bestCurrentDnaStart = -1;
				int currentSequence = 0;
				int startOfSequence = -1;

				for (int i = 0; i < dnaLength; i++)
				{
					if (dna[i] == 1)
					{
						if (startOfSequence == -1)
						{
							startOfSequence = i;
						}

						currentSequence++;

						if (bestCurrentDnaSequence < currentSequence)
						{
							bestCurrentDnaSequence = currentSequence;
							bestCurrentDnaStart = startOfSequence;
						}
					}
					else
					{
						startOfSequence = -1;
						currentSequence = 0;
					}
				}

				if ((bestCurrentDnaSequence > bestDnaSequence) ||
					(bestCurrentDnaSequence == bestDnaSequence && bestCurrentDnaStart < bestDnaStart) ||
					(bestCurrentDnaSequence == bestDnaSequence && bestCurrentDnaStart == bestDnaStart && dna.Sum() > bestDna.Sum()))
				{
					bestDnaIndex = dnaIndex;
					bestDnaStart = bestCurrentDnaStart;
					bestDnaSequence = bestCurrentDnaSequence;
					bestDna = dna;
				}
			}

			Console.WriteLine($"Best DNA sample {bestDnaIndex} with sum: {bestDna.Sum()}.");
			Console.WriteLine(string.Join(" ", bestDna));
		}
	}
}