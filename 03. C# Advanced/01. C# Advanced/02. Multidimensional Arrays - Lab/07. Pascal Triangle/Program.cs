namespace _07._Pascal_Triangle
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int rowCount = int.Parse(Console.ReadLine());
			long[][] jaggedArray = new long[rowCount][];

			PascalTriangle(rowCount, jaggedArray);

			foreach (long[] array in jaggedArray)
			{
				Console.WriteLine(string.Join(" ", array));
			}
		}

		private static void PascalTriangle(int rowCount, long[][] jaggedArray)
		{
			for (int i = rowCount - 1; i >= 0; i--)
			{
				long[] array = new long[rowCount - i];
				for (int j = 0; j < array.Length; j++)
				{
					if (j == 0 || j == array.Length - 1)
					{
						array[j] = 1;
						continue;
					}

					long[] prevArray = jaggedArray[rowCount - i - 2];
					array[j] = prevArray[j - 1] + prevArray[j];
				}

				jaggedArray[rowCount - i - 1] = array;
			}
		}
	}
}
