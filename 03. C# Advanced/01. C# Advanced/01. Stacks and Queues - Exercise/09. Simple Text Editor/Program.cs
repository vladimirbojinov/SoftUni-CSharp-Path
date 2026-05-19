namespace _09._Simple_Text_Editor
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int operationsCount = int.Parse(Console.ReadLine());
			string text = string.Empty;

			Stack<string[]> stack = new Stack<string[]>();	

			for (int i = 0; i < operationsCount; i++)
			{

				string[] command = Console.ReadLine().Split().ToArray();

				switch (command[0])
				{
					case "1": 
						text = AppendString(text , command[1]);
						stack.Push(command);
					break;
					case "2":
						text = EraseString(text, int.Parse(command[1]), stack);
					break;
					case "3":
						PrintAt(text, int.Parse(command[1]));
					break;
					case "4":
						text = Undo(text , stack);
					break;
				}
			}

		}

		public static string AppendString(string text, string appendedText)
		{
			text = string.Concat(text, appendedText);

			return text;
		}
		public static string EraseString(string text , int count, Stack<string[]> stack)
		{
			int indexToRemove = text.Length;
			string removedChars = string.Empty;
			for (int i = 1; i <= count; i++)
			{
				indexToRemove--;
				removedChars += text[indexToRemove];
				text = text.Remove(indexToRemove);
			}

			removedChars = ReverseString(removedChars);
			string[] array = { "2", removedChars};
			stack.Push(array);
			return text;
		}
		public static void PrintAt(string text, int index)
		{
			char charToPrint = text[index - 1];
			Console.WriteLine(charToPrint);
		}
		public static string Undo(string text, Stack<string[]> stack)
		{
			string[] commandToUndo = stack.Pop();

			switch (commandToUndo[0])
			{
				case "1": text = text.Replace(commandToUndo[1], ""); break;
				case "2": text = string.Concat(text, commandToUndo[1]); break;
			}

			return text;
		}
		public static string ReverseString(string input)
		{
			char[] charArray = input.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
