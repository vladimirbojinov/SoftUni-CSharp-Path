namespace _09._Greater_of_Two_Values
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string type = Console.ReadLine();

			if (type == "int")
			{
				int value1 = int.Parse(Console.ReadLine());
				int value2 = int.Parse(Console.ReadLine());

				Console.WriteLine(GetMax(value1, value2));
			}
			else if (type == "char")
			{
				char value1 = char.Parse(Console.ReadLine());
				char value2 = char.Parse(Console.ReadLine());

				Console.WriteLine(GetMax(value1, value2));
			}
			else
			{
				string value1 = Console.ReadLine();
				string value2 = Console.ReadLine();

				Console.WriteLine(GetMax(value1, value2));
			}
		}

		public static int GetMax(int value1, int value2)
		{
			if (value1 > value2)
			{
				return value1;
			}

			return value2;
		}

		public static char GetMax(char value1, char value2)
		{
			if (value1 > value2)
			{
				return value1;
			}

			return value2;
		}

		public static string GetMax(string value1, string value2)
		{
			int value1CharSum = 0;
			int value2CharSum = 0;

			for (int i = 0; i < value1.Length - 1; i++)
			{
				value1CharSum += value1[i];
			}

			for (int i = 0; i < value2.Length - 1; i++)
			{
				value2CharSum += value2[i];
			}

			if (value1CharSum > value2CharSum)
			{
				return value1;
			}

			return value2;
		}
	}
}