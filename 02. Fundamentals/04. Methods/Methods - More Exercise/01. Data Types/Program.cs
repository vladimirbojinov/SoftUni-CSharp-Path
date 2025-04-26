namespace _01._Data_Types
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string type = Console.ReadLine();

			switch (type)
			{
				case "int": HandleIntType(); break;
				case "real": HandleDoubleType(); break;
				case "string": HandleStringType(); break;
			}
		}

		private static void HandleIntType()
		{
			int value = int.Parse(Console.ReadLine());

			Console.WriteLine(value * 2);
		}

		private static void HandleDoubleType()
		{
			double value = double.Parse(Console.ReadLine());

			Console.WriteLine($"{value * 1.50:F2}");
		}

		private static void HandleStringType()
		{
			string value = Console.ReadLine();

			Console.WriteLine($"${value}$");
		}
	}
}
