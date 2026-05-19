namespace _08._Balanced_Parenthesis
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			bool endResult = false;

			Stack<char> stack = new Stack<char>();

			for (int i = 0; i < text.Length; i++)
			{
				if (!isBracketBalanced(text[i], stack))
				{
					endResult = false;
					break;
				}

				endResult = true;
			}

            if (endResult && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
			else
			{
				Console.WriteLine("NO");
			}
        }

		public static bool isBracketBalanced(char bracket, Stack<char> stack)
		{
			switch (bracket)
			{
				case '(':
				case '{':
				case '[':
					stack.Push(bracket);
					return true;

				case ')':
				case '}':
				case ']':
					if (stack.Count == 0) return false;
					char c = stack.Pop();
					if (c != '(' && bracket == ')' ||
						c != '{' && bracket == '}' ||
						c != '[' && bracket == ']')
					{
						return false;
					}

				break;
			}

			return true;
		}
	}
}
