
namespace _03._Periodic_Table
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int count = int.Parse(Console.ReadLine());

			HashSet<string> set = new HashSet<string>();

			for (int i = 0; i < count; i++)
			{
				string[] data = Console.ReadLine()
					.Split()
					.ToArray();

				FillSet(set, data);
			}

			set = set.OrderBy(x => x).ToHashSet();
            Console.WriteLine(string.Join(" ", set));
        }

		private static void FillSet(HashSet<string> set, string[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				set.Add(data[i]);
			}
		}
	}
}
