namespace _01._Generic_Box_of_String;

internal class Program
{
	static void Main(string[] args)
	{
		int count = int.Parse(Console.ReadLine());

		for (int i = 0; i < count; i++)
		{
			string value = Console.ReadLine();
			Box<string> box = new Box<string>(value);

			Console.WriteLine(box);
		}
        }
}
