using _04.Generi_SwapMethodInteger;

namespace _05.GenericCountMethodString;

internal class Program
{
	static void Main(string[] args)
	{
		List<Box<string>> boxList = FillList();

		string value = Console.ReadLine();
		Box<string>.GreaterThanCount(boxList, value);
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
