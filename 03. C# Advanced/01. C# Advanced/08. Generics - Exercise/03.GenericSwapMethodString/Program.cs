namespace _03.GenericSwapMethodString;

internal class Program
{
	static void Main(string[] args)
	{
		List<Box<string>> boxList = FillList();

		int[] array = Console.ReadLine()
			.Split(" ", StringSplitOptions.RemoveEmptyEntries)
			.Select(int.Parse)
			.ToArray();

		(int index1, int index2) = (array[0], array[1]);
		SwapValues(index1, index2, boxList);

        Console.WriteLine(string.Join("\n", boxList));
    }

	private static void SwapValues(int index1, int index2, List<Box<string>> boxList)
	{
		(boxList[index1], boxList[index2]) = (boxList[index2], boxList[index1]);
	}

	private static List<Box<string>> FillList()
	{
		List<Box<string>> boxList = new List<Box<string>>();

		int count = int.Parse(Console.ReadLine());

		for (int i = 0; i < count; i++)
		{
			string value = Console.ReadLine();
			Box<string> box = new Box<string>(value);

			boxList.Add(box);
		}

		return boxList;
	}
}
