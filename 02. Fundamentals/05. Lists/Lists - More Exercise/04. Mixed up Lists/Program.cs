
namespace _04._Mixed_up_Lists
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<int> list1 = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			List<int> list2 = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			List<int> result = MixList(list1, list2);

			result.Sort();
			Console.WriteLine(string.Join(" ", result));
		}

		private static List<int> MixList(List<int> list1, List<int> list2)
		{
			List<int> result = new List<int>();

			int minCount = GetMinValue(list1.Count, list2.Count);

			for (int i = 0; i < minCount; i++)
			{
				result.Add(list1[i]);
				result.Add(list2[list2.Count - 1 - i]);
			}

			list1.RemoveRange(0, minCount);
			list2.RemoveRange(list2.Count - minCount, minCount);

			int firstRange = 0;
			int secondRange = 0;
			if (list1.Count > 0)
			{
				firstRange = list1[0];
				secondRange = list1[1];
			}
			else
			{
				firstRange = list2[0];
				secondRange = list2[1];
			}

			if (firstRange > secondRange)
			{
				int temp = firstRange;
				firstRange = secondRange;
				secondRange = temp;
			}

			for (int i = 0; i < result.Count; i++)
			{
				if (result[i] <= firstRange || result[i] >= secondRange)
				{
					result.RemoveAt(i);
					i--;
				}
			}

			return result;
		}

		private static int GetMinValue(int num1, int num2)
		{
			int minCount;
			if (num1 < num2)
			{
				minCount = num1;
			}
			else
			{
				minCount = num2;
			}

			return minCount;
		}
	}
}
