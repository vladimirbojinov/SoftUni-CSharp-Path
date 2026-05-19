namespace CustomList;

internal class Program
{
	static void Main(string[] args)
	{
		List<string> list = new();
		CustomList<int> customList = new();

		customList.Add(101);
		customList.Add(0);
		customList.Add(3);
		customList.Add(4);
		customList.Add(5);
		customList.Add(6);
		customList.Reverse();

		foreach (int item in customList)
		{
			Console.WriteLine(item);
		}
	}
}
