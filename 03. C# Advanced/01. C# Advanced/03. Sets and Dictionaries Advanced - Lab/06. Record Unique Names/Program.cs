namespace _06._Record_Unique_Names
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());
		
			HashSet<string> set = new HashSet<string>();

			for (int i = 0; i < count; i++)
			{
				string name = Console.ReadLine();
				set.Add(name);
			}

			foreach (string name in set)
			{
				Console.WriteLine(name);
			}
		}
	}
}
