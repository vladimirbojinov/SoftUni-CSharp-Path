
namespace _02._Sets_of_Elements
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] data = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int firstCount = data[0];
			int secondCount = data[1];

			HashSet<int> setN = new HashSet<int>();
			HashSet<int> setM = new HashSet<int>();

			FillSet(setN, firstCount);
			FillSet(setM, secondCount);

			foreach (int number in setN)
			{
				if (setM.Contains(number))
				{
                    Console.Write($"{number} ");
                }
			}
		}

		private static void FillSet(HashSet<int> set, int count)
		{
			for (int i = 0; i < count; i++)
			{
				int number = int.Parse(Console.ReadLine());

				set.Add(number);
			}
		}
	}
}
