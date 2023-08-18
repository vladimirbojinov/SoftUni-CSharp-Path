namespace _02._Pascal_Triangle
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int numberOfRows = int.Parse(Console.ReadLine());

			int[] row = { 1 };
			Console.WriteLine(1);
			for (int i = 0; i < numberOfRows - 1; i++)
			{
				int[] changedRow = new int[row.Length + 1];
				for (int j = 0; j < row.Length + 1; j++)
				{
					if (j == 0 || j == row.Length)
					{
					}
					else
					{
						int index = j;
						changedRow[j] = row[index--] + row[index];
					}
				}

				changedRow[0] = 1;
				int length = changedRow.Length - 1;
				changedRow[length] = 1;

				Console.WriteLine(string.Join(" ", changedRow));

				row = changedRow;
			}
		}
	}
}