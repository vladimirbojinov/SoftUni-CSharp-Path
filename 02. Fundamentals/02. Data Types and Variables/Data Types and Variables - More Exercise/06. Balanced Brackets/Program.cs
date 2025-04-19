namespace _06._Balanced_Brackets
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int loops = int.Parse(Console.ReadLine());

			bool isBalanced = true;
			bool isClosed = false;
			bool isLastOpenBracket = false;

			int openBrackets = 0;

			for (int i = 0; i <= loops; i++)
			{
				string input = Console.ReadLine();

				if (input == "(")
				{
					isClosed = false;
					if (isLastOpenBracket)
					{
						isBalanced = false;
						break;
					}

					openBrackets++;
					isLastOpenBracket = true;
				}
				else if (input == ")")
				{
					isLastOpenBracket = false;
					isClosed = true;

					openBrackets--;
					if (openBrackets < 0)
					{
						isBalanced = false;
						break;
					}
				}
			}

			if (isBalanced && isClosed)
			{
				Console.WriteLine("BALANCED");
			}
			else
			{
				Console.WriteLine("UNBALANCED");
			}
		}
	}
}