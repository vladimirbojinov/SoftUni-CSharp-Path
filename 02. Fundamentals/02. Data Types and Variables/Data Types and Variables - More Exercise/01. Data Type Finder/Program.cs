namespace _01._Data_Type_Finder
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			string type = string.Empty;

			while (input != "END")
			{
				if (int.TryParse(input, out int intValue))
				{
					type = "integer";
				}
				else if (double.TryParse(input, out double doubleValue))
				{
					type = "floating point";
				}
				else if (char.TryParse(input, out char charValue))
				{
					type = "character";
				}
				else if (bool.TryParse(input, out bool boolValue))
				{
					type = "boolean";
				}
				else
				{
					type = "string";
				}

				Console.WriteLine($"{input} is {type} type");

				input = Console.ReadLine();
			}
		}
	}
}