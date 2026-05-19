namespace _01._Reverse_a_String
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();

			Stack<char> stack = new Stack<char>();

			for (int i = 0; i < text.Length; i++)
			{
				stack.Push(text[i]);
			}

			foreach (char c in stack)
			{
				Console.Write(c);
			}
		}
	}
}
