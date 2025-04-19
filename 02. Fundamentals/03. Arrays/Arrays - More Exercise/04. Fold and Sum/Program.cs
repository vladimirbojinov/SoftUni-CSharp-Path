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

			int[] leftSide = new int[array.Length / 2];
			int[] rightSide = new int[array.Length / 2];

			int count = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (i < array.Length / 2)
				{
					leftSide[i] = array[i];
				}
				else
				{
					rightSide[count] = array[i];
					count++;
				}
			}

			int[] leftSideSummed = new int[leftSide.Length / 2];
			int[] rightSideSummed = new int[rightSide.Length / 2];
			int reversedIndex = leftSide.Length - 1;
			for (int i = 0; i < leftSide.Length / 2; i++)
			{
				leftSideSummed[i] = leftSide[i] + leftSide[reversedIndex];
				rightSideSummed[i] = rightSide[i] + rightSide[reversedIndex];

				reversedIndex--;
			}

			Array.Reverse(leftSideSummed);
			Console.Write(string.Join(" " ,leftSideSummed) + " ");
			Console.Write(string.Join(" " ,rightSideSummed));
		}
	}
}