using System.Diagnostics;
using System.Threading.Channels;

namespace _01._Action_Print
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] array = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			Action<string> print = x => Console.WriteLine(x);
			Array.ForEach(array, print);
		}
	}
}
