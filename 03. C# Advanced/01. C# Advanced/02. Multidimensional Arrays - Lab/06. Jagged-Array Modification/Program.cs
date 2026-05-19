namespace _06._Jagged_Array_Modification
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int rowCount = int.Parse(Console.ReadLine());

			int[][] jaggedArray = new int[rowCount][];

			jaggedArray = FillArray(jaggedArray, rowCount);

			string command = string.Empty;
			while ((command = Console.ReadLine()) != "END")
			{
				string[] data = command
					.Split()
					.ToArray();

				int row = int.Parse(data[1]);
				int col = int.Parse(data[2]);
				int value = int.Parse(data[3]);

				switch (data[0])
				{
					case "Add":AddValues(row, col, value, jaggedArray); break;
					case "Subtract": SubtractValues(row, col, value, jaggedArray); break;
				}
			}

			foreach (int[] array in jaggedArray)
			{
                Console.WriteLine(string.Join(" ", array));
            }
		}
		public static int[][] FillArray(int[][] jaggedArray, int rowCount)
		{
			for (int i = 0; i < rowCount; i++)
			{
				int[] data = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				jaggedArray[i] = data;
			}

			return jaggedArray;
		}
		public static void AddValues(int row, int col, int value, int[][] jaggedArray)
		{
			if (jaggedArray.Length > row && row >= 0)
			{
				if (jaggedArray[row].Length > col && col >= 0)
				{
					jaggedArray[row][col] += value;
					return;
				}
			}

			Console.WriteLine("Invalid coordinates");
		}
		public static void SubtractValues(int row, int col, int value, int[][] jaggedArray)
		{
			if (jaggedArray.Length > row && row >= 0)
			{
				if (jaggedArray[row].Length > col && col >= 0)
				{
					jaggedArray[row][col] -= value;
					return;
				}
			}

			Console.WriteLine("Invalid coordinates");
		}
	}
}
