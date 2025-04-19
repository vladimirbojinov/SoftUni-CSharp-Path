namespace _04._Array_Rotation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();
			int loops = int.Parse(Console.ReadLine());

			for (int i = 0; i < loops; i++)
			{
				int[] tempArray = new int[array.Length];
				for (int j = 1; j < array.Length; j++)
				{
					tempArray[j - 1] = array[j];
				}
				tempArray[array.Length - 1] = array[0];
				array = tempArray;
			}

			Console.WriteLine(string.Join(" ", array));
		}
	}
}