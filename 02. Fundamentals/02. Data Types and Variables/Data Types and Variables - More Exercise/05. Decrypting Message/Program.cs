namespace _05._Decrypting_Message
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int key = int.Parse(Console.ReadLine());
			int loops = int.Parse(Console.ReadLine());

			string message = string.Empty;

			for (int i = 0; i < loops; i++)
			{
				char letter = char.Parse(Console.ReadLine());
				message += (char)(letter + key);
			}

			Console.WriteLine(message);
		}
	}
}