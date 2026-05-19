namespace _02.Collection;

internal class Program
{
	static void Main(string[] args)
	{
		string[] data = Console.ReadLine()
			.Split(' ', StringSplitOptions.RemoveEmptyEntries);

		ListyIterator<string> listyIterator = new ListyIterator<string>(data.Skip(1));
		string command;
		while ((command = Console.ReadLine()) != "END")
		{
			try
			{
				switch (command)
				{
					case "Move": Console.WriteLine(listyIterator.Move()); break;
					case "HasNext": Console.WriteLine(listyIterator.HasNext()); break;
					case "Print": listyIterator.Print(); break;
					case "PrintAll": listyIterator.PrintAll(); break;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
