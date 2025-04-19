namespace _05._Longest_Increasing_Subsequence
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int[] len = new int[array.Length];
			int[] prev = new int[array.Length];
			int bestLength = 0;

			for (int i = 0; i < array.Length; i++)
			{
				int bestIndex = -1;
				bestLength = 0;

				for (int j = 0; j < i; j++)
				{
					if (array[i] > array[j] && 
						bestLength < len[j])
					{
						bestIndex = j;
						bestLength = len[j];
					}
				}

				prev[i] = bestIndex;
				len[i] = bestLength + 1;
			}

			int bestLengthIndex = -1;
			bestLength = 0;
			for (int i = 0; i < len.Length; i++)
			{
				if (bestLength < len[i])
				{
					bestLengthIndex = i;
					bestLength = len[i];
				}
			}

			int[] lis = new int[bestLength];
			int prevIndex = bestLengthIndex;
			int index = 0;
			while (prevIndex != -1)
			{
				lis[index++] = array[prevIndex];
				prevIndex = prev[prevIndex];
			}

			Console.WriteLine(string.Join(' ', lis.Reverse()));
		}
	}
}