namespace _04.Generi_SwapMethodInteger;

internal class Program
{
	static void Main(string[] args)
	{
		List<Box<int>> boxList = FillList();

		int[] array = Console.ReadLine()
			.Split(" ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

		(int index1, int index2) = (array[0], array[1]);
		SwapValues(index1, index2, boxList);

		Console.WriteLine(string.Join("\n", boxList));
	}

	private static void SwapValues(int index1, int index2, List<Box<int>> boxList)
	{
		(boxList[index1], boxList[index2]) = (boxList[index2], boxList[index1]);
	}

	private static List<Box<int>> FillList()
	{
		List<Box<int>> boxList = new List<Box<int>>();

		int count = int.Parse(Console.ReadLine());

		for (int i = 0; i < count; i++)
		{
			int value = int.Parse(Console.ReadLine());
			Box<int> box = new Box<int>(value);

			boxList.Add(box);
		}

		return boxList;
	}
}
