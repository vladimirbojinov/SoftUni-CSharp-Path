namespace _02._Pascal_Triangle
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int rowCount = int.Parse(Console.ReadLine());

			int[] oldRow = new int[1];
			int[] newRow = new int[1];

			for (int i = 0; i < rowCount; i++)
			{
				for (int j = 0; j < newRow.Length; j++)
				{
					if (j == 0 || j == newRow.Length - 1)
					{
						newRow[j] = 1;
					}
					else
					{
						newRow[j] = oldRow[j - 1] + oldRow[j];
					}
				}

				Console.WriteLine(string.Join(' ', newRow));
				oldRow = newRow;
				newRow = new int[oldRow.Length + 1];
			}
		}
	}
}