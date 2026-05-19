namespace _02._Average_Student_Grades
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Dictionary<string, List<decimal>> dictionary = new Dictionary<string, List<decimal>>();
			int count = int.Parse(Console.ReadLine());

			for (int i = 0; i < count; i++)
			{
				string[] data = Console.ReadLine()
					.Split()
					.ToArray();

				string name = data[0];
				decimal grade = decimal.Parse(data[1]);

				if (!dictionary.ContainsKey(name))
				{
					dictionary[name] = new List<decimal>();
				}

				dictionary[name].Add(grade);
			}

			foreach ((string name, var gradesList) in dictionary)
			{
				Console.Write($"{name} -> ");
				foreach (decimal grade in gradesList)
				{
                    Console.Write($"{grade:F2} ");
                }
                Console.WriteLine($"(avg: {gradesList.Average():F2})");
            }
		}
	}
}
