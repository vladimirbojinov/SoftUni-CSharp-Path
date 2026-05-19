using System.Threading.Tasks.Dataflow;

namespace _05._Applied_Arithmetics
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int[] array = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			Dictionary<string, Action<int[]>> operationsMap = new Dictionary<string, Action<int[]>>()
			{
				["add"] = arr => executeCommand(arr, num => num + 1),
				["subtract"] = arr => executeCommand(arr, num => num - 1),
				["multiply"] = arr => executeCommand(arr, num => num * 2),
				["print"] = arr => Console.WriteLine(string.Join(" ", arr)),
			};

			string command;
			while ((command = Console.ReadLine()) != "end")
			{
				operationsMap[command](array);
			}

		}

		private static void executeCommand(int[] arr, Func<int, int> func)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = func(arr[i]);
			}
		}
	}
}
