namespace _04._Matching_Brackets
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string expression = Console.ReadLine();
			Stack<int> stackIndexBrackets = new Stack<int>();

			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '(')
				{
					stackIndexBrackets.Push(i);
				}
				else if (expression[i] == ')')
				{
					int lastIndex = stackIndexBrackets.Pop();
					string subExpression = expression.Substring(lastIndex, i - lastIndex + 1);
					Console.WriteLine(subExpression);
				}
			}
		}
	}
}
