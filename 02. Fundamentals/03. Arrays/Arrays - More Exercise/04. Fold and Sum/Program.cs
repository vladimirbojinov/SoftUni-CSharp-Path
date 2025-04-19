namespace _04._Fold_and_Sum
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int[] arrayFirstPart = new int[array.Length / 2];
			int[] arraySecondPart = new int[array.Length / 2];

			int count = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (i < array.Length / 2)
				{
					arrayFirstPart[i] = array[i];
				}
				else
				{
					arraySecondPart[count] = array[i];
					count++;
				}
			}

			int[] arrayFirstPartSummed = new int[arrayFirstPart.Length / 2];
			int[] arraySecondPartSummed = new int[arraySecondPart.Length / 2];
			int reversedIndex = arrayFirstPart.Length - 1;
			for (int i = 0; i < arrayFirstPart.Length / 2; i++)
			{
				int index = i;

				arrayFirstPartSummed[index] = arrayFirstPart[index] + arrayFirstPart[reversedIndex];
				arraySecondPartSummed[index] = arraySecondPart[index] + arraySecondPart[reversedIndex];

				reversedIndex--;
			}

			Array.Reverse(arrayFirstPartSummed);

			Console.Write(string.Join(" " ,arrayFirstPartSummed) + " ");
			Console.Write(string.Join(" " ,arraySecondPartSummed));
		}
	}
}