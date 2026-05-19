namespace CustomRandomList;

public class StartUp
{
	static void Main(string[] args)
	{
		RandomList list = new RandomList();

		list.Add("Name1");
		list.Add("Name2");
		list.Add("Name3");
		list.Add("Name4");

		Console.WriteLine(list.RandomString());
	}
}
