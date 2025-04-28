
namespace _08._Anonymous_Threat
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> data = Console.ReadLine()
				.Split()
				.ToList();

			string command;
			while ((command = Console.ReadLine()) != "3:1")
			{
				string[] input = command.Split();
				switch (input[0])
				{
					case "merge": Merge(data, int.Parse(input[1]), int.Parse(input[2])); break;
					case "divide": Divide(data, int.Parse(input[1]), int.Parse(input[2])); break;
				}
			}

			Console.WriteLine(string.Join(" ", data));
		}

		private static void Divide(List<string> data, int elementIndex, int portionSize)
		{
			List<string> splitData = new List<string>();

			string dataToSplit = data[elementIndex];
			data.RemoveAt(elementIndex);

			int splitCount = dataToSplit.Length / portionSize;
			int remain = dataToSplit.Length % portionSize;

			int index = 0;

			for (int i = 0; i < portionSize - 1; i++)
			{
				splitData.Add(dataToSplit.Substring(index, splitCount));
				index += splitCount;
			}

			splitData.Add(dataToSplit.Substring(index, splitCount + remain));
			splitData.Reverse();

			foreach (string currentData in splitData)
			{
				data.Insert(elementIndex, currentData);
			}
		}

		private static void Merge(List<string> data, int index1, int index2)
		{
			index1 = Math.Max(0, Math.Min(data.Count - 1, index1));
			index2 = Math.Max(0, Math.Min(data.Count - 1, index2));

			if (index1 == index2)
			{
				return;
			}

			string mergedData = string.Empty;
			for (int i = 0; i <= index2 - index1; i++)
			{
				mergedData += data[index1 + i];
			}

			data.RemoveRange(index1, index2 - index1 + 1);
			data.Insert(index1, mergedData);
		}
	}
}
