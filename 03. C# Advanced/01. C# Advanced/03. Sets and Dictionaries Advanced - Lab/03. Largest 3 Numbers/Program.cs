namespace _03._Largest_3_Numbers
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.OrderByDescending(x => x)
				.ToArray();

			if (array.Length > 3)
			{
				for (int i = 0; i < 3; i++)
				{
					Console.Write($"{array[i]} ");
                }
			}
			else
			{
                Console.WriteLine(string.Join(" ", array));
            }
 		}
	}
}
